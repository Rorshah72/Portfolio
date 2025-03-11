using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portfolio.Shared.Infrastructure.Repository
{
    // Інтерфейс репозиторію(можливо якось покарщити?)
    public interface IRepository<T> :
    IGetByIdRepository<T>,
    IGetAllRepository<T>,
    IFindRepository<T>,
    IAddRepository<T>,
    IUpdateRepository<T>,
    IDeleteRepository<T>,
    IExistsRepository<T>
    where T : class
    { }

    // Інтерфейс для отримання сутності за ідентифікатором
    public interface IGetByIdRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
    }

    // Інтерфейс для отримання всіх сутностей
    public interface IGetAllRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }

    // Інтерфейс для пошуку сутностей за умовою
    public interface IFindRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }

    // Інтерфейс для додавання нової сутності
    public interface IAddRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }

    // Інтерфейс для оновлення існуючої сутності
    public interface IUpdateRepository<T> where T : class
    {
        Task UpdateAsync(T entity);
    }

    // Інтерфейс для видалення сутності
    public interface IDeleteRepository<T> where T : class
    {
        Task DeleteAsync(T entity);
    }

    // Інтерфейс для перевірки існування сутності за умовою
    public interface IExistsRepository<T> where T : class
    {
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
