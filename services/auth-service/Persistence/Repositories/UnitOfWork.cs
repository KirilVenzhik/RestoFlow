using Application.Interfaces.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        RefreshTokens = new RefreshTokenRepository(context);
    }

    public IUserRepository Users { get; }
    public IRefreshTokenRespository RefreshTokens { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
