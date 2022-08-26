using CrossCutting.Core;
using FluentValidation;
using MediatR;

namespace Infra.Data.Query.Queries.v1
{
    public class GetAccountQuery : CustomValidator, IRequest<GetAccountQueryResponse>
    {
        public GetAccountQuery(string account)
        {
            Account = account;
        }

        public string Account { get; set; }

        public override Task<bool> IsValid() => Valid<GetAccountQueryValidator, GetAccountQuery>(this);
    }

    public class GetAccountQueryValidator : AbstractValidator<GetAccountQuery>
    {
        public GetAccountQueryValidator()
        {
            RuleFor(x => x.Account)
                .NotEmpty();
        }
    }
}