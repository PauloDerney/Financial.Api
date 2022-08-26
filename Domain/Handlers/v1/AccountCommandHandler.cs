using CrossCutting.Exceptions;
using Domain.Commands.v1;
using Domain.Contracts.v1;
using MediatR;

namespace Domain.Handlers.v1
{
    public class AccountCommandHandler : IRequestHandler<AddAccount>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Unit> Handle(AddAccount request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountAsync(request.Name, cancellationToken);

            if (account != null)
                throw new AlreadyExistException("Account already exist in database.");

            account = new Entities.Account { Name = request.Name, Balance = request.Balance, Tag = request.Tag, Type = request.Type };

            await _accountRepository.InsertAccountAsync(account, cancellationToken);

            return Unit.Value;
        }
    }
}