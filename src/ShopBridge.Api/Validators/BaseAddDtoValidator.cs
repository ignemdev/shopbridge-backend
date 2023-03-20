using FluentValidation;
using ShopBridge.Core.DTOs;

namespace ShopBridge.Api.Validators;

public class BaseAddDtoValidator : AbstractValidator<BaseAddDto>
{
    public BaseAddDtoValidator()
    {
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
