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
    }
}
