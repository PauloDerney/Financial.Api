using CrossCutting.Exceptions;
using Domain.Enums;

namespace Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Tag { get; set; }
        public decimal Balance { get; set; } = 0;
        public AccountType Type { get; set; }
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void CashOut(decimal amount)
        {
            if (Balance < amount)
                throw new BalanceException("Insuficient balance to complete operation.");

            var transaction = new Transaction(Balance, Balance - amount, amount, OperationType.Withdraw);

            Transactions.Add(transaction);
            Balance = transaction.NewAmount;
        }
    }

    public class Transaction
    {
        public Transaction(decimal oldAmount, decimal newAmount, decimal operationAmount, OperationType operation)
        {
            OldAmount = oldAmount;
            NewAmount = newAmount;
            OperationAmount = operationAmount;
            Operation = operation;
            Date = DateTime.UtcNow;
        }

        public decimal OldAmount { get; set; }
        public decimal NewAmount { get; set; }
        public decimal OperationAmount { get; set; }
        public OperationType Operation { get; set; }
        public DateTime Date { get; set; }
    }
}