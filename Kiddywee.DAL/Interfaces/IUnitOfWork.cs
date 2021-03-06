﻿using Kiddywee.DAL.Models;
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
        IGenericRepository<ApplicationUser> Users { get; }
        IGenericRepository<Attendance> Attendances { get; }

        IGenericRepository<ChildInfo> ChildInfos { get; }
        IGenericRepository<StaffInfo> StaffInfos { get; }
        IGenericRepository<FileInfo> FileInfos { get; }
        IGenericRepository<Contact> Contacts { get; }       
        IGenericRepository<PersonToContact> PersonToContacts { get; }
        IGenericRepository<PersonToChild> PersonToChildren { get; }

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
        IGenericRepository<DailyReportNote> DailyReportNotes { get; }
        IGenericRepository<DailyReportNap> DailyReportNaps { get; }
        IGenericRepository<DailyReportMeal> DailyReportMeals { get; }
        IGenericRepository<DailyReportFood> DailyReportFoods { get; }
        IGenericRepository<DailyReportBathroom> DailyReportBathrooms { get; }
        IGenericRepository<DailyReportMedication> DailyReportMedications { get; }
        void Save();
        Task<IdentityResult> SaveAsync();
        Task<IdentityResult> SaveFileAsync();
    }
}
