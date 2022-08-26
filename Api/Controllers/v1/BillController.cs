using Api.Core;
using Domain.Commands.v1;
using Infra.Data.Query.Queries.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1
{
    [ApiController]
    [Route("api/financial")]
    public class BillController : RestFullController<BillController>
    {
        public BillController(ILogger<BillController> logger, IMediator mediator)
            : base(logger, mediator) { }

        [HttpPost("v1/bills")]
        public async Task<IActionResult> AddBillAsync(AddBill command)
            => await SafeExecuteHandlerAsync(command, HttpStatusCode.Created);

        [HttpPost("v1/accounts")]
        public async Task<IActionResult> AddAccountAsync(AddAccount command)
            => await SafeExecuteHandlerAsync(command, HttpStatusCode.Created);

        [HttpGet("v1/accounts/{accountName}")]
        public async Task<IActionResult> GetAccountAsync(string accountName)
            => await SafeExecuteHandlerAsync(new GetAccountQuery(accountName), HttpStatusCode.OK);
    }
}