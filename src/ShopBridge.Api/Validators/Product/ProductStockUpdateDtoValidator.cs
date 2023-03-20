using FluentValidation;
using ShopBridge.Core.DTOs.Product;

namespace ShopBridge.Api.Validators.Product;

public class ProductStockUpdateDtoValidator : AbstractValidator<ProductStockUpdateDto>
{
    public ProductStockUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(GlobalConstants.ValueZero);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(GlobalConstants.ValueOne);
    }
}
