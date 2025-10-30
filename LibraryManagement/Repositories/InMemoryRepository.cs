using LibraryManagement.Models.Entities;
using LibraryManagement.Repositories.Interfaces;

namespace LibraryManagement.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _entities = new();
    private int _nextId = 1;

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_entities.AsEnumerable());
    }

    public Task<T?> GetByIdAsync(int id)
    {
        var entity = _entities.FirstOrDefault(e => GetId(e) == id);
        return Task.FromResult(entity);
    }

    public Task<T> AddAsync(T entity)
    {
        SetId(entity, _nextId++);
        _entities.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<T> UpdateAsync(T entity)
    {
        var id = GetId(entity);
        var existingEntity = _entities.FirstOrDefault(e => GetId(e) == id);
        if (existingEntity != null)
        {
            _entities.Remove(existingEntity);
            _entities.Add(entity);
        }
        return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var entity = _entities.FirstOrDefault(e => GetId(e) == id);
        if (entity != null)
        {
            _entities.Remove(entity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    private static int GetId(T entity)
    {
        return entity switch
        {
            Author author => author.Id,
            Book book => book.Id,
            _ => throw new InvalidOperationException($"Unsupported entity type: {typeof(T).Name}")
        };
    }

    private static void SetId(T entity, int id)
    {
        switch (entity)
        {
            case Author author:
                author.Id = id;
                break;
            case Book book:
                book.Id = id;
                break;
            default:
                throw new InvalidOperationException($"Unsupported entity type: {typeof(T).Name}");
        }
    }
}