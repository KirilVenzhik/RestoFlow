using Application.Interfaces.Services;
using Domain.Entitites;
using Domain.Enums;

namespace Application.Services;

public class OrderStatusServcie : IOrderStatusService
{
    public async Task SetStatusAsync(Order order, OrderStatus newStatus)
    {
        if (!IsTransitionValid(order.Status, newStatus))
        {
            throw new InvalidOperationException($"Transition from {order.Status} to {newStatus} is not allowed.");
        }

        order.Status = newStatus;
        order.UpdatedAt = DateTime.Now;

        await Task.CompletedTask;
    }

    public bool IsTransitionValid(OrderStatus current, OrderStatus next)
    {
        return current switch
        {
            OrderStatus.Pending => next is OrderStatus.Processing or OrderStatus.Canceled,
            OrderStatus.Processing => next is OrderStatus.Delivering or OrderStatus.Canceled,
            OrderStatus.Delivering => next == OrderStatus.Completed,
            OrderStatus.Completed or OrderStatus.Canceled => false,
            _ => false
        };
    }
}
