namespace AuthMS.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync (T entity, CancellationToken ct);
    Task UpdateAsync(T entity, CancellationToken ct);
    }