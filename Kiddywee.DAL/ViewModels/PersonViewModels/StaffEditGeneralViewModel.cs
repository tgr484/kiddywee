using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class StaffEditGeneralViewModel
    {
        public StaffEditGeneralViewModel()
        {            
            
        }

        public Guid PersonId { get; set; }   

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
        public int PhoneNumberDigitPin { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string NormalizedDateOfBirth
        {
            get
            {
                return DateOfBirth.HasValue ? DateOfBirth?.ToString("dd MMMM yyyy") : "";
            }
        }
    }
}
