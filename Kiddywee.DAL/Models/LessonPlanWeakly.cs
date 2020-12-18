using Kiddywee.DAL.ViewModels.EducationViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class LessonPlanWeakly : BaseEntity
    {
        public Guid OrgnizationId { get; set; }
        public Organization Orgnization { get; set; }

        public Guid? ClassId { get; set; }

        public Class Class { get; set; }

        public Guid? SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid? CurriculumToSubjectId { get; set; }
        public CurriculumToSubject CurriculumToSubject { get; set; }

        public DateTime WeekDateSunday { get; set; }
        public string Theme { get; set; }
        public string Notes { get; set; }
        public string TeacherNotes { get; set; }

        public static LessonPlanWeakly Create(LessonPlanViewModel model, DateTime weekDaySunday, string userId)
        {
            return new LessonPlanWeakly()
            { 
                Theme = model.WeeklyTheme,
                ClassId = model.ClassId,
                OrgnizationId = new Guid("2675d289-f8cd-4596-ad75-dfa58ee817af"),
                WeekDateSunday = weekDaySunday,
                CreatedById = userId
            };
        }

        public static IEnumerable<LessonPlanJson> ToJson(List<LessonPlanWeakly> weeklyLessonPlan)
        {
            List<LessonPlanJson> result = new List<LessonPlanJson>();
            foreach (var p in weeklyLessonPlan)
            {
                result.Add(new LessonPlanJson() 
                { 
                    start = p.WeekDateSunday.AddDays(-6), 
                    end = p.WeekDateSunday.AddDays(-1) , 
                    title = p.Theme, 
                    backgroundColor = "#28a745" });
                }
            return result;
        }
    }
}
