using Portfolio.Services.CoreAPI.Repositories;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Services
{
    //need rework
    public interface ICoreSkillsOfWork
    {
        ISkillRepository Skills { get; }
    }

    public interface ICoreProjectsOfWork
    {
        IProjectRepository Projects { get; }
    }

    public interface ICoreUnitOfWork : ICoreSkillsOfWork, ICoreProjectsOfWork
    {
        Task<int> CompleteAsync();
    }
}
