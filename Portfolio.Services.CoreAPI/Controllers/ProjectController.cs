using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.CoreAPI.Services;
using Portfolio.Shared.Models;

namespace Portfolio.Services.CoreAPI.Controllers
{
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly ICoreUnitOfWork _unitOfWork;

        public ProjectController(ICoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var projects = await _unitOfWork.Projects.GetByIdAsync(id);
            if (projects == null) return NotFound();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Project project)
        {
            if (id != project.Id) return BadRequest();
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null) return NotFound();
            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
