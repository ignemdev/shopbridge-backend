using FluentValidation;
using ShopBridge.Core.DTOs.Product;

namespace ShopBridge.Api.Validators.Product;

public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateDtoValidator()
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

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(GlobalConstants.ValueOne);
    }
}
