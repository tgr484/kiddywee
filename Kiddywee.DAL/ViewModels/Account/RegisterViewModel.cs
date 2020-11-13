using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
       
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Too short password")]
        public string Password { get; set; }
    }
}
