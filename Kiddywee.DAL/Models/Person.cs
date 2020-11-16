using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Person
    {
        public Person()
        {
            Contacts = new List<PersonToContact>();
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? ChildInfoId { get; set; }

        public ChildInfo ChildInfo { get; set; }

        public List<PersonToContact> Contacts { get; set; }

        public Guid? OrganizationId { get; set; } 

        public Organization Orgnization { get; set; }
        public Guid? StaffInfoId { get; set; }
        public StaffInfo StaffInfo { get; set; }

        public static Person Create(string firstName, string lastName)
        {
            return new Person() { FirstName = firstName, LastName = lastName };
        }
    }
}
