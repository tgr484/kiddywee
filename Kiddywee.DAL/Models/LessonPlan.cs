﻿using Kiddywee.DAL.ViewModels.EducationViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class LessonPlan : BaseEntity
    {
        public Guid OrganizationId { get; set; }
        public Organization Orgnization { get; set; }

        public Guid? ClassId { get; set; }

        public Class Class { get; set; }

        public Guid? SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid? CurriculumToSubjectId { get; set; }
        public CurriculumToSubject CurriculumToSubject { get; set; }

        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Notes { get; set; }
        public string TeacherNotes { get; set; }

        public static LessonPlanViewModel Init(LessonPlan lessonPlan)
        {
            return new LessonPlanViewModel()
            {
                LessonPlanId = lessonPlan.Id,
                Notes = lessonPlan.Notes,
                Theme = lessonPlan.Theme,
                ClassId = lessonPlan.ClassId,
                Date = lessonPlan.Date,
                
            };
        }

        public static List<LessonPlanJson> ToJson(List<LessonPlan> lessonPlansForClass)
        {
            List<LessonPlanJson> result = new List<LessonPlanJson>();
            foreach(var p in lessonPlansForClass)
            {
                result.Add(new LessonPlanJson() { start = p.Date, title = p.Theme});
            }
            return result;
        }

        public static LessonPlan Create(LessonPlanViewModel model, string userId)
        {
            return new LessonPlan()
            {
                Date = model.Date,
                Theme = model.Theme,
                Notes = model.Notes,
                CreatedById = userId,
                ClassId = model.ClassId,
                OrganizationId = new Guid("2675d289-f8cd-4596-ad75-dfa58ee817af"),
            };
        }

        public void Update(LessonPlanViewModel model)
        {
            Theme = model.Theme;
            Notes = model.Notes;
        }
    }

    public class LessonPlanJson
    {
        public string title { get; set; }
        public DateTime start { get; set; }

        public DateTime? end { get; set; }

        public string backgroundColor { get; set; }
    }
}
