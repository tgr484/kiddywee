using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class CurriculumSubjectGoal : BaseEntity
    {
        public string Name { get; set; }
        public string LearningStandardIdentifier { get; set; }  

        public Guid CurriculumToSubjectId { get; set; }
        public CurriculumToSubject CurriculumToSubject { get; set; }
        
    }
}
