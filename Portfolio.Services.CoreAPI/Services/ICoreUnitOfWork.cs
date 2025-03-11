using Portfolio.Services.CoreAPI.Repositories;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Services
{
    //need rework
    public interface ICoreSkillsOfWork
    {
        IRepository<Skill> Skills { get; }
    }

    public interface ICoreProjectsOfWork
    {
        IRepository<Project> Projects { get; }
    }

    public interface ICoreUnitOfWork : ICoreSkillsOfWork, ICoreProjectsOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
