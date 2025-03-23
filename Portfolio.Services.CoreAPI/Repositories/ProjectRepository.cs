using Portfolio.Services.CoreAPI.Data;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(CoreDbContext context) : base(context) { }
    }
}
