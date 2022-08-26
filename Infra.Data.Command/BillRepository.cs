using CrossCutting.Configuration;
using Domain.Contracts.v1;
using Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infra.Data.Command
{
    public class BillRepository : IBillRepository
    {
        private readonly IMongoCollection<Bill> _collection;

        public BillRepository(IOptions<TransactionDbSettings> mongoDbSettings)
        {
            _collection = new MongoClient(mongoDbSettings.Value.ConnectionUri)
                                .GetDatabase(mongoDbSettings.Value.Database)
                                .GetCollection<Bill>(nameof(Bill));
        }

        public async Task InsertAsync(Bill bill, CancellationToken cancellationToken = default)
            => await _collection.InsertOneAsync(bill, cancellationToken: cancellationToken);
    }
}