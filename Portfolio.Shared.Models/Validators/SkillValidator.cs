using FluentValidation;
using Portfolio.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models.Validators
{
    public class SkillValidator : AbstractValidator<SkillDto>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Skill name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");
        }
    }
}
