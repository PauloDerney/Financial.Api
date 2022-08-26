using CrossCutting.Core;
using FluentValidation;
using MediatR;

namespace Domain.Commands.v1
{
    public class AddBill : CustomValidator, IRequest
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Tag { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }

        public override async Task<bool> IsValid() => await Task.FromResult(true);
    }

    public class AddBillValidator : AbstractValidator<AddBill>
    {
        public AddBillValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.Tag)
                .NotEmpty();

            RuleFor(c => c.Amount)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(c => c.PaymentMethod)
                .NotEmpty();
        }
    }
}