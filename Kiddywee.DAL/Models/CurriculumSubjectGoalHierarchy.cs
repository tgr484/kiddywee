using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class CurriculumSubjectGoalHierarchy : BaseEntity
    {
        public Guid CurriculumSubjectGoalId { get; set; }
        public CurriculumSubjectGoal CurriculumSubjectGoal { get; set; }
        public Guid? CurriculumSubjectGoalHierarchyParentId { get; set; }
        public CurriculumSubjectGoalHierarchy CurriculumSubjectGoalHierarchyParent { get; set; }

        public string Text { get; set; }

    }
}
