using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.ClassesViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Class : BaseEntity
    {
        public Class()
        {
            Curriculums = new List<Curriculum>();
            DailyReportTypes = new List<int>();
            Subjects = new List<Subject>();
        }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Name { get; set; }
        public EnumStageType StageType { get; set; }

        public List<int> DailyReportTypes { get; set; }

        public List<Curriculum> Curriculums { get; set; }
        public List<Subject> Subjects { get; set; }

        public int? EnrollmentSpots { get; set; }

        public int? TeacherStudentRatio { get; set; }

        public static List<ClassViewModel> Init(List<Class> classes)
        {
            var result = new List<ClassViewModel>();
            foreach (var cls in classes)
            {
                result.Add(new ClassViewModel() { ClassName = cls.Name, ClassId = cls.Id });
            }
            return result;
        }


        public static Class Create(ClassCreateViewModel model, string userId)
        {
            return new Class()
            {
                Name = model.Name,
                StageType = model.StageType,
                DailyReportTypes = model.DailyReportTypes,
                EnrollmentSpots = model.EnrollmentSpots,
                CreatedById = userId,
                //OrganizationId = model.OrganizationId,
                OrganizationId = new Guid("2675d289-f8cd-4596-ad75-dfa58ee817af"),
                TeacherStudentRatio = model.TeacherStudentRatio
            };
        }
    }
}
