using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class RegisterViewModel
    {
        [MinLength(6, ErrorMessage = "Username length must be atleast 6.")]
        public string Username { get; set; }
        [MinLength(6, ErrorMessage = "Password length must be atleast 6 for safety purpose.")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be a valid Email address")]
        public string Email { get; set; }
    }
}
