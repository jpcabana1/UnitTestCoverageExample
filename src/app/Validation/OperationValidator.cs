using app.Dto;
using FluentValidation;

namespace app.Validation
{
    public class OperationValidator : AbstractValidator<OperationRequest>
    {
        public OperationValidator()
        {
            RuleFor(op => op.Parameter1).NotNull();
            RuleFor(op => op.Parameter2).NotNull();
            RuleFor(op => op.Operation).Matches("[+]|[-]|[*]|[/]")
            .WithMessage("Operation must be +, -, * or /");
        }
    }
}