using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class CurriculumToSubject : BaseEntity
    {
        public string Name { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }
        public Guid CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Guid? ClassId { get; set; }

        public Class Class { get; set; }

        
    }
}
