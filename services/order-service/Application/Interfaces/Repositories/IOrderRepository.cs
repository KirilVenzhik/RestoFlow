using Domain.Entitites;

namespace Application.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetAllByUserIdAsync(Guid userId);
    Task AddAsync(Order order);
    void Update(Order order);
    void Delete(Order order);
}
