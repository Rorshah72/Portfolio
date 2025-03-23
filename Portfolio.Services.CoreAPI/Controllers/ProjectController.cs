using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.CoreAPI.Services;
using Portfolio.Shared.Models;
using Portfolio.Shared.Models.DTOs;
using Portfolio.Shared.Models.Validators;

namespace Portfolio.Services.CoreAPI.Controllers
{
    [ApiController]   
    [Route("api/projects")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ICoreUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectController(ICoreUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Fetching all resumes");
            var projects = await _unitOfWork.Projects.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
        {
            _logger.LogInformation("Creating a new project: {@Project}", projectDto);
            var validationProject = new ProjectValidator().Validate(projectDto);
            if (!validationProject.IsValid)
            {
                _logger.LogWarning("Project validation failed: {@Errors}", validationProject.Errors);
                return BadRequest(validationProject.Errors);
            }                

            var project = _mapper.Map<Project>(projectDto);
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("Project created whith ID: {@id}", project.Id);

            return CreatedAtAction(nameof(GetById), new { id = project.Id }, _mapper.Map<Project>(projectDto));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProjectDto projectDto)
        {
            if (id != projectDto.Id) return BadRequest();

            var validationProject = new ProjectValidator().Validate(projectDto);
            if (!validationProject.IsValid)
                return BadRequest(validationProject.Errors);

            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null) return NotFound();

            _mapper.Map(projectDto, project);
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null) return NotFound();

            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
