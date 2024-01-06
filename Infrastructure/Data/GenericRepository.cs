using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T>(AppDbContext dbContext) : IRepository<T>
    where T : Entity
{
    protected readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public async Task<T> GetByIdAsync(string id) =>
        await _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}