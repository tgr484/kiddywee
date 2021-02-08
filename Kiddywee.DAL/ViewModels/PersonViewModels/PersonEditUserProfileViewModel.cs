using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class PersonEditUserProfileViewModel
    {
        public PersonEditUserProfileViewModel()
        {            
            
        }

        public Guid PersonId { get; set; }   

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }       

        public string FullName => FirstName + " " + LastName;

        public string NormalizedDateOfBirth
        {
            get
            {
                return DateOfBirth.HasValue ? DateOfBirth?.ToString("dd MMMM yyyy") : "";
            }
        }

        public static PersonEditUserProfileViewModel Init(Person person, ApplicationUser user)
        {
            return new PersonEditUserProfileViewModel()
            {
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonId = person.Id,
                Email = user.Email
            };
        }
    }
}
