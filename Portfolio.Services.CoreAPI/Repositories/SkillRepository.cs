using Portfolio.Services.CoreAPI.Data;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(CoreDbContext context) : base(context) { }
    }
}
