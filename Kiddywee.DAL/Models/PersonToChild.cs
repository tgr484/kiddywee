using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class PersonToChild : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Guid ChildId { get; set; }

        public Person Child { get; set; }

        public static PersonToChild Create(Guid personId, Guid childId, string createdUserId)
        {
            return new PersonToChild()
            {
                PersonId = personId,
                ChildId = childId,
                CreatedById = createdUserId
            };
        }
    }
}
