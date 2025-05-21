namespace Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
    Task<int> SaveChangesAsync();
}
