using FluentValidation;

using CardProcessing.Domain;
using CardProcessing.Service.Contract;

namespace CardProcessing.Service.Validation;

public class AllowedCardActionsRequestValidator : AbstractValidator<AllowedCardActionsRequest>
{
    public AllowedCardActionsRequestValidator()
    {
        RuleFor(m => m.UserId).NotEmpty()
            .WithMessage("UserId cannot be empty.");
        RuleFor(m => m.UserId).MaximumLength(Constraints.UserId_MaxLength)
            .WithMessage($"UserId can be up to {Constraints.UserId_MaxLength} characters long.");

        RuleFor(m => m.CardNumber).NotEmpty()
            .WithMessage("CardNumber cannot be empty.");
        RuleFor(m => m.CardNumber).MaximumLength(Constraints.CardNumber_MaxLength)
            .WithMessage($"CardNumber can be up to {Constraints.CardNumber_MaxLength} characters long.");
    }
}