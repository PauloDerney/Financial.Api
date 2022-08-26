using Domain.Enums;
using MediatR;

namespace Domain.Notifications.v1
{
    public class TransactionNotification : INotification
    {
        public TransactionNotification(string accountName, decimal operationAmount, OperationType operation)
        {
            AccountName = accountName;
            OperationAmount = operationAmount;
            Operation = operation;
        }

        public string AccountName { get; set; }
        public decimal OperationAmount { get; set; }
        public OperationType Operation { get; set; }

        public string GetTransactionMessage() => $"R$ {OperationAmount} successfully {Operation.ToString().ToLower()} for account {AccountName}.";
    }
}