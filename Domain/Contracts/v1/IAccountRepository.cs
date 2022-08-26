using Domain.Entities;

namespace Domain.Contracts.v1
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync(string name, CancellationToken cancellationToken = default);
        Task UpdateAccountAsync(Account account, CancellationToken cancellationToken = default);
        Task InsertAccountAsync(Account account, CancellationToken cancellationToken = default);
    }
}