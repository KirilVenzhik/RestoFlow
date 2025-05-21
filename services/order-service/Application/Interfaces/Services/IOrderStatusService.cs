using Domain.Entitites;
using Domain.Enums;

namespace Application.Interfaces.Services;

public interface IOrderStatusService
{
    Task SetStatusAsync(Order order, OrderStatus newStatus);
    bool IsTransitionValid(OrderStatus current, OrderStatus next);
}
