using Application.Interfaces.Repositories;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    private readonly AppDbContext _context;

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetAllByUserIdAsync(Guid userId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Where(o => o.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
         await _context.Orders.AddAsync(order);
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
