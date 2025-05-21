namespace Application.DTOs;

public class CreateOrderDto
{
    public Guid RestaurantId { get; set; }
    public AddressDto DeliveryAddress { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = new();
}
