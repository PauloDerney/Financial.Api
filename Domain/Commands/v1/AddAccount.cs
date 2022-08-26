using CrossCutting.Core;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Domain.Commands.v1
{
    public class AddAccount : CustomValidator, IRequest
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }

        public override async Task<bool> IsValid() => await Valid<AddAcountValidator, AddAccount>(this);
    }

    public class AddAcountValidator : AbstractValidator<AddAccount>
    {
        public AddAcountValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Tag)
                .NotEmpty();

            RuleFor(x => x.Type)
                .NotEmpty()
                .IsInEnum();
        }
    }
}