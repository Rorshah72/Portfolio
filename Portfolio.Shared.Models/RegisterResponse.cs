using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
