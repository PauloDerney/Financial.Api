using FluentValidation;
using FluentValidation.Results;

namespace CrossCutting.Core
{
    public abstract class CustomValidator
    {
        protected ValidationResult? _result;

        public IEnumerable<string> GetErrors() => _result?.Errors?.Select(x => x.ErrorMessage) ?? new List<string>(0);

        public abstract Task<bool> IsValid();

        protected async Task<bool> Valid<TValidator, TCommand>(TCommand command) where TValidator : AbstractValidator<TCommand>, new()
        {
            _result = await new TValidator().ValidateAsync(command);
            return _result.IsValid;
        }
    }
}