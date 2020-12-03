using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class PersonToContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public static PersonToContact Create(Guid childId, Guid contactId, string _userId)
        {
            return new PersonToContact()
            {
                ContactId = contactId,
                CreatedById = _userId,
                PersonId = childId
            };
        }
    }
}
