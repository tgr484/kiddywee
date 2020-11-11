using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
