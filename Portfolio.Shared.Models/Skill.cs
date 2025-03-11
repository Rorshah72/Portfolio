using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    class Skill
    {
        /// <summary>
        /// Unique identifier for the skill.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the skill.
        /// </summary>
        /// <remarks>
        /// This field is required.
        /// </remarks>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the skill.
        /// </summary>
        /// <remarks>
        /// This field is required.
        /// </remarks>
        public string Description { get; set; } = null!;

        /// <summary>
        /// URL of the image representing the skill.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Type of the skill.
        /// </summary>
        public SkillType Type { get; set; }

        /// <summary>
        /// Level of proficiency in the skill.
        /// </summary>
        public SkillLevel Level { get; set; }

        /// <summary>
        /// Programming language associated with the skill.
        /// </summary>
        public string? ProgrammingLanguage { get; set; }

        /// <summary>
        /// Date when the skill was acquired.
        /// </summary>
        public DateTime DateAcquired { get; set; }

        /// <summary>
        /// Validates the skill properties.
        /// </summary>
        /// <returns>True if valid, otherwise false.</returns>
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;

            if (string.IsNullOrWhiteSpace(Description))
                return false;

            if (DateAcquired == default)
                return false;

            return true;
        }
    }
}
