using Application.DTOs;
using Domain.Enums;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(CreateOrderDto dto);
    Task<OrderDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    Task CancelOrderAsync(Guid orderId);
}