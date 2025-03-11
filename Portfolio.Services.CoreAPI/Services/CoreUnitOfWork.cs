using Portfolio.Services.CoreAPI.Data;
using Portfolio.Services.CoreAPI.Repositories;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Services
{
    public class CoreUnitOfWork : ICoreUnitOfWork
    {
        private readonly CoreDbContext _context;
        
        public IRepository<Skill> Skills { get; }
        public IRepository<Project> Projects { get; }

        public CoreUnitOfWork(CoreDbContext context)
        {
            _context = context;            
            Skills = new Repository<Skill>(context);
            Projects = new Repository<Project>(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
