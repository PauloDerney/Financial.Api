using CrossCutting.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Core
{
    public class RestFullController<TController> : Controller where TController : class
    {
        protected readonly ILogger<TController> Logger;
        protected readonly IMediator Mediator;

        public RestFullController(ILogger<TController> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        protected async Task<IActionResult> SafeExecuteHandlerAsync<TCommand>(TCommand command, HttpStatusCode statusCode = HttpStatusCode.OK)
            where TCommand : CustomValidator
        {
            try { return await GenerateResponseAsync(command, statusCode); }

            catch (CustomExceptionType customEx)
            {
                Logger.LogError(customEx, "Error in requesting to route. {command}", command);

                var error = new { Notifications = new string[] { customEx.ErrorMessage } };

                return new ObjectResult(error) { StatusCode = (int)customEx.StatusCode };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in requesting to route. {command}", command);

                var defaultError = new
                {
                    Notifications = new string[] { "Unexpected error! Please, contact administrator of system." }
                };

                return new ObjectResult(defaultError) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        private async Task<IActionResult> GenerateResponseAsync<TCommand>(TCommand command, HttpStatusCode statusCode = HttpStatusCode.OK)
            where TCommand : CustomValidator
        {
            if (await command.IsValid())
            {
                var response = await Mediator.Send(command);

                var data = new
                {
                    Data = response
                };

                return new ObjectResult(data) { StatusCode = (int)statusCode };
            }
            else
            {
                return BadRequest(new
                {
                    Notifications = command.GetErrors()
                });
            }
        }
    }
}