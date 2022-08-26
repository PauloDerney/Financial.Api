using Domain.Contracts.v1;
using Domain.Notifications.v1;
using MediatR;

namespace Domain.Handlers.v1
{
    public class NotificationHandler : INotificationHandler<TransactionNotification>
    {
        private readonly INotificationClient _notificationClient;

        public NotificationHandler(INotificationClient notificationClient)
        {
            _notificationClient = notificationClient;
        }

        public async Task Handle(TransactionNotification notification, CancellationToken cancellationToken)
        {
            await _notificationClient.SendTelegramNotificationAsync(notification.GetTransactionMessage());
        }
    }
}