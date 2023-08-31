

using Microsoft.EntityFrameworkCore;
using WebAccountant.Application.Persistence.Contracts;

namespace WebAccountant.Persistence.Repository.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly WebAccountantDbContext.WebAccountantDbContext _context;

    public GenericRepository(WebAccountantDbContext.WebAccountantDbContext context)
    {
        _context = context;
    }


    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        SaveChangesAsync();
        return entity;

    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var entity = await GetById(id);
        _context.Set<T>().Remove(entity);
        SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> Isexist(int id)
    {
        var entity = await GetById(id);
        return entity != null;
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        SaveChangesAsync();
    }

    public async void SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
