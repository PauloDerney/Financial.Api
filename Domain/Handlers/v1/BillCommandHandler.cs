using CrossCutting.Exceptions;
using Domain.Commands.v1;
using Domain.Contracts.v1;
using Domain.Entities;
using Domain.Notifications.v1;
using MediatR;

namespace Domain.Handlers.v1
{
    public class BillCommandHandler : IRequestHandler<AddBill>
    {
        private readonly IMediator _mediator;
        private readonly IBillRepository _billRepository;
        private readonly IAccountRepository _accountRepository;

        public BillCommandHandler(IBillRepository billRepository, IMediator mediator, IAccountRepository accountRepository)
        {
            _billRepository = billRepository;
            _mediator = mediator;
            _accountRepository = accountRepository;
        }

        public async Task<Unit> Handle(AddBill request, CancellationToken cancellationToken)
        {
            ValuesObjects.Payment? payment = null;

            if (!string.IsNullOrEmpty(request.PaymentMethod))
            {
                var account = await _accountRepository.GetAccountAsync(request.PaymentMethod, cancellationToken);

                if (account is null)
                    throw new NotFoundException("Account not found for this tag or name.");

                payment = new ValuesObjects.Payment(request.PaymentDate, account.Tag);
            }

            var bill = new Bill(request.Name, request.Amount, request.Tag, request.PurchaseDate, payment);

            await _billRepository.InsertAsync(bill, cancellationToken);

            if (bill.Payment != null)
                await _mediator.Publish(new CashOutNotification(bill.Payment.Method, bill.Amount));

            return Unit.Value;
        }
    }
}