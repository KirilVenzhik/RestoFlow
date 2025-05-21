using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .WithMessage("RestaurantId is required.");

        RuleFor(x => x.DeliveryAddress)
            .NotNull()
            .WithMessage("Delivery address is required.")
            .SetValidator(new AddressDtoValidator());

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Order must contain items.")
            .Must(items => items.Any())
            .WithMessage("Order must contain at least one item.");

        RuleForEach(x => x.Items)
            .SetValidator(new CreateOrderItemDtoValidator());
    }
}
