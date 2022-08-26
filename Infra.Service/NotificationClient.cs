using CrossCutting.Configuration;
using Domain.Contracts.v1;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Infra.Service
{
    public class NotificationClient : INotificationClient
    {
        private readonly string _chatId;
        private readonly string _baseUrl;

        public NotificationClient(IOptions<ClientSettings> clientSettings)
        {
            _baseUrl = clientSettings.Value.Notification.Url;
            _chatId = clientSettings.Value.Notification.CustomValues["ChatId"];
        }

        public async Task SendTelegramNotificationAsync(string message, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest()
                .AddBody(new { ChatId = _chatId, Message = message });

            var response = await new RestClient($"{_baseUrl}/api/notifications/v1/telegram")
                                        .PostAsync(request, cancellationToken);
        }
    }
}