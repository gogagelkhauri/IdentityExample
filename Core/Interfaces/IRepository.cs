using Core.Entities;

namespace Core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(string id);

    void Update(T entity);

}