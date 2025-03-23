using Portfolio.Services.CoreAPI.Data;
using Portfolio.Services.CoreAPI.Repositories;
using Portfolio.Services.CoreAPI.Services;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Repositories
{
    public class CoreUnitOfWork : ICoreUnitOfWork
    {
        private readonly CoreDbContext _context;

        public CoreUnitOfWork(CoreDbContext context)
        {
            _context = context;            
            Skills = new SkillRepository(context);
            Projects = new ProjectRepository(context);
        }

        
        public ISkillRepository Skills { get; }
        public IProjectRepository Projects { get; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    }
}

