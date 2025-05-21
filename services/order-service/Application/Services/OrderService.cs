using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderStatusService _statusService;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderStatusService statusService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _statusService = statusService;
    }

    public async Task<OrderDto?> GetByIdAsync(Guid id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        
        if (order == null)
            return null;
         
        return _mapper.Map<OrderDto?>(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId)
    {
        var orders = await _unitOfWork.Orders.GetAllByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<Guid> CreateOrderAsync(CreateOrderDto dto)
    {
        var order = _mapper.Map<Order>(dto);
        order.Status = OrderStatus.Pending;
        order.CreatedAt = DateTime.UtcNow;
        order.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        return order.Id;
    }

    public async Task CancelOrderAsync(Guid orderId)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId)
            ?? throw new KeyNotFoundException("Order not found");

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId)
            ?? throw new KeyNotFoundException("Order not found");

        await _statusService.SetStatusAsync(order, status);

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();
    }
}
