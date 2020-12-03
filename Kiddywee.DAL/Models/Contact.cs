using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Models
{
    public class Contact : BaseEntity
    {
        public EnumContactType ContactType { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
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

        public static ChildEditContactInformationViewModel Init(List<Contact> contacts, Guid childId)
        {
            List<ChildContactViewModel> contactsViewModels = new List<ChildContactViewModel>();

            foreach(var item in contacts)
            {
                contactsViewModels.Add(new ChildContactViewModel()
                {
                    FullName = item.FullName,
                    ContactId = item.Id,
                    GuardianId = item.GuardianId,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                });
            }

            return new ChildEditContactInformationViewModel() { ChildId = childId, Contacts = contactsViewModels};
        }

        public static Contact Create(ChildCreateContactViewModel model, string _userId)
        {
            return new Contact()
            {
                Address = model.Address,
                CreatedById = _userId,
                Email = model.Email,
                FirstName = model.FirstName,
                ChildId = model.ChildId,
                LastName = model.LastName,
                Notes = model.Notes,
                PhoneHome = model.PhoneHome,
                PhoneMobile = model.PhoneMobile,
                PhoneWork = model.PhoneWork
            };
        }
    }
}
