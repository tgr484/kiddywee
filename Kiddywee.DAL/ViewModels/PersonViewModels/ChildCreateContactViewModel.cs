using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildCreateContactViewModel
    {
        public Guid ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Address { get; set; }
        public string Email { get; set; }

        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }

        public string Notes { get; set; }
    }
}
