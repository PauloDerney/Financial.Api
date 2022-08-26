namespace Domain.Contracts.v1
{
    public interface INotificationClient
    {
        Task SendTelegramNotificationAsync(string message, CancellationToken cancellationToken = default);
    }
}