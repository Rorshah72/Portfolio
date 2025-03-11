using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// Username for login
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password for login
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = null!;
    }
}
