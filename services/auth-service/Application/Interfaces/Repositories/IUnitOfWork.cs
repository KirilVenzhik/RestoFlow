namespace Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IRefreshTokenRespository RefreshTokens { get; }
    Task<int> SaveChangesAsync();
}
