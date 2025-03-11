using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class User
    {
        /// <summary>  
        /// Unique identifier for the user.  
        /// </summary>  
        public Guid Id { get; set; }

        /// <summary>  
        /// Username of the user.  
        /// </summary>  
        [Required]
        public string Username { get; set; } = null!;

        /// <summary>  
        /// Email address of the user.  
        /// </summary>  
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>  
        /// First name of the user.  
        /// </summary>  
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>  
        /// Last name of the user.  
        /// </summary>  
        [Required]
        public string LastName { get; set; } = null!;

        /// <summary>  
        /// URL of the user's photo.  
        /// </summary>  
        [Url]
        public string? PhotoUrl { get; set; }

        /// <summary>  
        /// Telegram link of the user.  
        /// </summary>  
        [Url]
        public string? TelegramLink { get; set; }

        /// <summary>  
        /// GitHub link of the user.  
        /// </summary>  
        [Url]
        public string? GitHubLink { get; set; }

        /// <summary>  
        /// LinkedIn link of the user.  
        /// </summary>  
        [Url]
        public string? LinkedInLink { get; set; }

        /// <summary>  
        /// Phone number of the user.  
        /// </summary>  
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
