using MediatR;

namespace Domain.Notifications.v1
{
    public class CashOutNotification : INotification
    {
        public CashOutNotification(string account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }

        public string Account { get; set; }
        public decimal Amount { get; set; }
    }
}