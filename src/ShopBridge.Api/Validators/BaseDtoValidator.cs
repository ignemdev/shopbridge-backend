using FluentValidation;
using ShopBridge.Core.DTOs;

namespace ShopBridge.Api.Validators;

public class BaseDtoValidator : AbstractValidator<BaseDto>
{
    public BaseDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(GlobalConstants.ValueZero);

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(GlobalConstants.ValueOne)
            .MaximumLength(GlobalConstants.DefaultMediumStringMaxLength);

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MinimumLength(GlobalConstants.ValueOne)
            .MaximumLength(GlobalConstants.DefaultLargeStringMaxLength);
    }
}
