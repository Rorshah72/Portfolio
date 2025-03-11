using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    class Project
    {
        // Unique identifier for the project
        public Guid Id { get; set; }

        // Name of the project, required
        public string Name { get; set; } = null!;

        // Description of the project, required
        public string Description { get; set; } = null!;

        // URL to the project's image, optional
        public string? ImageUrl { get; set; }

        // URL to the project's GitHub repository, optional
        public string? GitHubLink { get; set; }

        // URL to the live project, optional
        public string? LiveUrl { get; set; }

        // Status of the project
        public ProjectStatus Status { get; set; }

        // Date when the project was created
        public DateTime DateCreated { get; set; }

        // Date when the project was completed, optional
        public DateTime? DateCompleted { get; set; }

        // List of technologies used in the project
        public List<string> Technologies { get; set; } = new();

        // Validate the project properties
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentException("Description is required.");
            }

            if (DateCreated == default)
            {
                throw new ArgumentException("DateCreated is required.");
            }
        }
    }
}
