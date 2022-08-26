using Infra.Data.Query.Queries.v1;

namespace Infra.Data.Query.Contracts
{
    public interface IGetAccountRepository
    {
        Task<GetAccountQueryResponse> GetAccountAsync(string accountName);
    }
}