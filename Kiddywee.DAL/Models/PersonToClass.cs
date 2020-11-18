using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class PersonToClass: BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid ClassId{ get; set; }

        public Person Person { get; set; }
        public Class Class { get; set; } 


        public static PersonToClass Create(Guid personId, Guid classId, string createdBy)
        {
            return new PersonToClass() { PersonId = personId, ClassId = classId, CreatedById = createdBy };
        }
    }
}
