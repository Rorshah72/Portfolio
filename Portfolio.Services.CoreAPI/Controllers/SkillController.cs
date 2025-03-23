using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.CoreAPI.Services;
using Portfolio.Shared.Models;
using Portfolio.Shared.Models.DTOs;
using Portfolio.Shared.Models.Validators;
using System;

namespace Portfolio.Services.CoreAPI.Controllers
{
    [Route("api/skills")]
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ILogger<SkillController> _logger;
        private readonly ICoreUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillController(ICoreUnitOfWork unitOfWork, IMapper mapper, ILogger<SkillController> logger)
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
            var skills = await _unitOfWork.Skills.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<SkillDto>>(skills));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var skills = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skills == null) return NotFound();
            return Ok(_mapper.Map<SkillDto>(skills));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillDto skillDto)
        {
            _logger.LogInformation("Creating a new skill: {@Skill}", skillDto);
            var validationSkill = new SkillValidator().Validate(skillDto);
            if (!validationSkill.IsValid)
            {
                _logger.LogWarning("Skill validation failed: {@Errors}", validationSkill.Errors);
                return BadRequest(validationSkill.Errors);
            }                

            var skill = _mapper.Map<Skill>(skillDto);
            await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("Skill created whith ID: {@id}", skill.Id);

            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, _mapper.Map<SkillDto>(skill));


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SkillDto skillDto)
        {
            if (id != skillDto.Id) return BadRequest();

            var validationSkill = new SkillValidator().Validate(skillDto);
            if (!validationSkill.IsValid)
                return BadRequest(validationSkill.Errors);

            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null) return NotFound();

            _mapper.Map(skillDto, skill);
            _unitOfWork.Skills.Update(skill);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null) return NotFound();

            _unitOfWork.Skills.Delete(skill);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
