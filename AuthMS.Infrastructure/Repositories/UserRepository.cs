using AuthMS.Domain.Interfaces;
using AuthMS.Domain.Entities;
using AuthMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AuthMS.Domain.ValueObjects;

namespace AuthMS.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Users
        .FirstOrDefaultAsync(u => u.Id ==UserId.Create(id), ct);
    }

    public async Task<UserEntity?> GetByLoginAsync(string login, CancellationToken ct)
    {
        return await _context.Users
        .FirstOrDefaultAsync(u => u.Login ==Login.Create(login), ct);
    }

    public async Task AddAsync(UserEntity entity ,CancellationToken ct)
    {
        await _context.Users.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(UserEntity entity, CancellationToken ct)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync(ct);
    }
}
