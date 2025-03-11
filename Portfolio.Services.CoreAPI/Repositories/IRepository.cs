namespace Portfolio.Services.CoreAPI.Repositories
{
    public interface IGetAllAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }

    public interface IGetByIdAsync<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
    }

    public interface IAddAsync<T> where T : class
    {
        Task AddAsync(T entity);
    }

    public interface IUpdate<T> where T : class
    {
        void Update(T entity);
    }

    public interface IDelete<T> where T : class
    {
        void Delete(T entity);
    }

    public interface ISaveChangesAsync
    {
        Task<int> SaveChangesAsync();
    }

    public interface IRepository<T> : IGetAllAsync<T>, IGetByIdAsync<T>, IAddAsync<T>, IUpdate<T>, IDelete<T>, ISaveChangesAsync where T : class
    {
    }
}
