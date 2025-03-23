using System.Linq.Expressions;

namespace Portfolio.Services.CoreAPI.Repositories
{
    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {
    }
}
