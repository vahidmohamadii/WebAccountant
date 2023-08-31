

namespace WebAccountant.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T:class
{
    Task<T> GetById(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Isexist(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteById(int id);
}
