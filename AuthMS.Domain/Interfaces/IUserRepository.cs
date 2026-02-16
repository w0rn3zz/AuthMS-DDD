using AuthMS.Domain.Entities;

namespace AuthMS.Domain.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity?> GetByLoginAsync(string login, CancellationToken ct);
}