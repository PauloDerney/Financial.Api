using CrossCutting.Configuration;
using Domain.Contracts.v1;
using Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infra.Data.Command
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountRepository(IOptions<TransactionDbSettings> mongoDbSettings)
        {
            _collection = new MongoClient(mongoDbSettings.Value.ConnectionUri)
                                            .GetDatabase(mongoDbSettings.Value.Database)
                                            .GetCollection<Account>(nameof(Account));
        }

        public async Task<Account> GetAccountAsync(string name, CancellationToken cancellationToken = default)
            => await _collection.Find(x => x.Name.Equals(name) || x.Tag.Equals(name)).SingleOrDefaultAsync(cancellationToken);

        public async Task UpdateAccountAsync(Account account, CancellationToken cancellationToken = default)
            => await _collection.FindOneAndReplaceAsync(x => x.Name.Equals(account.Name), account, cancellationToken: cancellationToken);

        public async Task InsertAccountAsync(Account account, CancellationToken cancellationToken = default)
            => await _collection.InsertOneAsync(account, cancellationToken: cancellationToken);
    }
}