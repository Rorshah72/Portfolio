using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.CoreAPI.Services;
using Portfolio.Shared.Models;
using System;

namespace Portfolio.Services.CoreAPI.Controllers
{
    [Route("api/skills")]
    public class SkillController : Controller
    {
        private readonly ICoreUnitOfWork _unitOfWork;

        public SkillController(ICoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var skills = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skills == null) return NotFound();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Skill skill)
        {
            await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Skill skill)
        {
            if (id != skill.Id) return BadRequest();
            _unitOfWork.Skills.Update(skill);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null) return NotFound();
            _unitOfWork.Skills.Delete(skill);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
