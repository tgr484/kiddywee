using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Person> People { get; }

        IGenericRepository<ChildInfo> ChildInfos { get; }
        IGenericRepository<StaffInfo> StaffInfos { get; }
        IGenericRepository<MedicalInfo> MedicalInfos { get; }
        IGenericRepository<Contact> Contacts { get; }       
        IGenericRepository<PersonToContact> PersonToContacts { get; }       
        IGenericRepository<Organization> Organizations { get;  }
        
        IGenericRepository<Class> Classes { get;  }
        IGenericRepository<Subject> Subjects { get;  }
        IGenericRepository<Curriculum> Curriculums { get;  }
        IGenericRepository<CurriculumSubjectGoal> CurriculumSubjectGoals { get;  }
        IGenericRepository<CurriculumSubjectGoalHierarchy> CurriculumSubjectGoalHierarchies { get;  }
        IGenericRepository<CurriculumToSubject> CurriculumToSubjects { get;  }
        IGenericRepository<LessonPlan> LessonPlans { get;  }
        IGenericRepository<LessonPlanWeakly> LessonPlanWeaklies { get;  }
        IGenericRepository<PersonToClass> PersonToClasses { get; }
        void Save();
        Task<IdentityResult> SaveAsync();
    }
}
