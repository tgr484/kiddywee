using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Contact : BaseEntity
    {
        public EnumContactType ContactType { get; set; }
        
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }

        public string Notes { get; set; }

        public Guid? ChildId { get; set; }

        public Person Child { get; set; }
        public Guid? GuardianId { get; set; }

        public Person Guardian { get; set; }
    }
}
