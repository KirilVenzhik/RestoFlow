namespace Application.DTOs;

public class CreateOrderDto
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public AddressDto DeliveryAddress { get; set; }
    public List<CreateOrderItemDto> Items { get; set; }
}
