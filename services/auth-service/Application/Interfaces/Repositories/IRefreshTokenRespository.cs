using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRefreshTokenRespository
{
    Task<RefreshToken?> GetByUserIdAsync(Guid id);
    Task AddAsync(RefreshToken refreshToken);
    void Update(RefreshToken refreshToken);
    void Delete(RefreshToken refreshToken);
}
