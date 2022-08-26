using Infra.Data.Query.Contracts;
using MediatR;

namespace Infra.Data.Query.Queries.v1
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountQueryResponse>
    {
        private readonly IGetAccountRepository _getAccountRepository;

        public GetAccountQueryHandler(IGetAccountRepository getAccountRepository)
        {
            _getAccountRepository = getAccountRepository;
        }

        public async Task<GetAccountQueryResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await _getAccountRepository.GetAccountAsync(request.Account);
        }
    }
}