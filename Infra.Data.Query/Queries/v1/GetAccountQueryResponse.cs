using Infra.Data.Query.Enums;

namespace Infra.Data.Query.Queries.v1
{
    public class GetAccountQueryResponse
    {
        public Guid Id { private get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public IEnumerable<GetAccountQueryResponseTransaction> Transactions { get; set; }
    }

    public class GetAccountQueryResponseTransaction
    {
        public decimal OldAmount { get; set; }
        public decimal NewAmount { get; set; }
        public decimal OperationAmount { get; set; }
        public OperationType Operation { get; set; }
        public DateTime Date { get; set; }
    }
}