using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.ClassesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Attendances = new List<Attendance>();
            PersonToClasses = new List<PersonToClass>();
        }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Name { get; set; }
        public EnumStageType StageType { get; set; }

        public List<int> DailyReportTypes { get; set; }

        public List<PersonToClass> PersonToClasses { get; set; }
        public List<Curriculum> Curriculums { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Attendance> Attendances { get; set; }
        public int? EnrollmentSpots { get; set; }

        public int? TeacherStudentRatio { get; set; }

        public static List<ClassViewModel> Init(List<Class> classes, List<Attendance> attendances, List<Person> persons)
        {
            var result = new List<ClassViewModel>();
            var staffInOrganization = persons.Where(x => x.StaffInfo != null);
            var childrenInOrganization = persons.Where(x => x.ChildInfo != null);
            foreach (var cls in classes)
            {
                var attendanceForClass = attendances.Where(x => x.ClassId == cls.Id);

                var staffInClass = staffInOrganization.Where(x => x.PersonToClasses.Any(p => p.IsActive && p.ClassId == cls.Id));
                var childrenInClass = childrenInOrganization.Where(x => x.PersonToClasses.Any(p => p.IsActive && p.ClassId == cls.Id));

                int staffInCount = 0;
                int childrenInCount = 0;

                foreach (var item in staffInClass)
                {
                    var attendance = attendanceForClass.FirstOrDefault(x => x.PersonId == item.Id);
                    if (attendance != null && !attendance.OutDate.HasValue)
                    {
                        ++staffInCount;
                    }
                }

                foreach (var item in childrenInClass)
                {
                    var attendance = attendanceForClass.FirstOrDefault(x => x.PersonId == item.Id);
                    if (attendance != null && !attendance.OutDate.HasValue)
                    {
                        ++childrenInCount;
                    }
                }

                result.Add(
                    new ClassViewModel()
                    {
                        ClassName = cls.Name,
                        ClassId = cls.Id.ToString(),
                        StaffIn = staffInCount,
                        ChildrenIn = childrenInCount,
                        StaffTotal = staffInClass.Count(),
                        ChildrenTotal = childrenInClass.Count()
                    });
            }
            return result;
        }


        public void Update(ClassEditViewModel model)
        {
            Name = model.Name;
            EnrollmentSpots = model.EnrollmentSpots;
            StageType = model.StageType;
            TeacherStudentRatio = model.TeacherStudentRatio;
        }
        public static ClassEditViewModel Init(Class @class, List<Class> classesExeptSelected)
        {
            return new ClassEditViewModel()
            {
                Name = @class.Name,
                EnrollmentSpots = @class.EnrollmentSpots,
                StageType = @class.StageType,
                OrganizationId = @class.OrganizationId,
                TeacherStudentRatio = @class.TeacherStudentRatio,
                ClassId = @class.Id,
                Classes = classesExeptSelected
            };
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
