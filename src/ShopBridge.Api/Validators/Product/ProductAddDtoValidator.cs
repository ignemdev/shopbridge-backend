using FluentValidation;
using ShopBridge.Core.DTOs.Product;

namespace ShopBridge.Api.Validators.Product;

public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
{
    public ProductAddDtoValidator()
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

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(GlobalConstants.ValueOne);
    }
}
