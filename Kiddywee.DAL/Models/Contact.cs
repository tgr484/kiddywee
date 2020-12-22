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

        public static ChildEditContactInformationViewModel Init(List<Contact> contacts, Guid childId)
        {
            List<ChildContactViewModel> contactsViewModels = new List<ChildContactViewModel>();

            foreach(var item in contacts)
            {
                contactsViewModels.Add(new ChildContactViewModel()
                {
                    FullName = item.FullName,
                    ContactId = item.Id,
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
                LastName = model.LastName,
                Notes = model.Notes,
                PhoneHome = model.PhoneHome,
                PhoneMobile = model.PhoneMobile,
                PhoneWork = model.PhoneWork
            };
        }

        public static ChildEditContactViewModel Edit(Contact contact, Guid childId)
        {
            return new ChildEditContactViewModel()
            {
                Address = contact.Address,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                ContactId = contact.Id,
                Notes = contact.Notes,
                PhoneHome = contact.PhoneHome,
                PhoneMobile = contact.PhoneMobile,
                PhoneWork = contact.PhoneWork,
                ChildId = childId
            };
        }

        public void Update(ChildEditContactViewModel model)
        {
            this.Address = model.Address;
            this.Email = model.Email;
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Notes = model.Notes;
            this.PhoneHome = model.PhoneHome;
            this.PhoneMobile = model.PhoneMobile;
            this.PhoneWork = model.PhoneWork;
        }
    }
}
