using CrossCutting.Configuration;
using Infra.Data.Query.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infra.Data.Query.Queries.v1
{
    public class GetAccountRepository : IGetAccountRepository
    {
        private readonly IMongoCollection<GetAccountQueryResponse> _collection;

        public GetAccountRepository(IOptions<ReadOnlyDbSettings> mongoDbSettings)
        {
            _collection = new MongoClient(mongoDbSettings.Value.ConnectionUri)
                                .GetDatabase(mongoDbSettings.Value.Database)
                                .GetCollection<GetAccountQueryResponse>("Account", new MongoCollectionSettings
                                {
                                    ReadPreference = new ReadPreference(ReadPreferenceMode.SecondaryPreferred),
                                    ReadConcern = new ReadConcern(ReadConcernLevel.Majority)
                                });
        }

        public Task<GetAccountQueryResponse> GetAccountAsync(string accountName)
            => _collection.Find(x => x.Tag.Equals(accountName) || x.Name.Equals(accountName)).SingleOrDefaultAsync();
    }
}