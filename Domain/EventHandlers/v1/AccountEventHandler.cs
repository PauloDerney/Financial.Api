using Domain.Contracts.v1;
using Domain.Notifications;
using Domain.Notifications.v1;
using MediatR;

namespace Domain.EventHandlers.v1
{
    public class AccountEventHandler : INotificationHandler<CashOutNotification>
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepository _accountRepository;

        public AccountEventHandler(IMediator mediator, IAccountRepository accountRepository)
        {
            _mediator = mediator;
            _accountRepository = accountRepository;
        }

        public async Task Handle(CashOutNotification request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountAsync(request.Account, cancellationToken);

            account.CashOut(request.Amount);

            await _accountRepository.UpdateAccountAsync(account, cancellationToken);

            await _mediator.Publish(new TransactionNotification(account.Tag, request.Amount, Enums.OperationType.Withdraw));
        }
    }
}