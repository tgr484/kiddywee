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
        IGenericRepository<Contact> Contacts { get; }       
        IGenericRepository<Organization> Organizations { get;  }
        
        IGenericRepository<Class> Classes { get;  }
        IGenericRepository<Subject> Subjects { get;  }
        IGenericRepository<Curriculum> Curriculums { get;  }
        IGenericRepository<CurriculumSubjectGoal> CurriculumSubjectGoals { get;  }
        IGenericRepository<CurriculumSubjectGoalHierarchy> CurriculumSubjectGoalHierarchies { get;  }
        IGenericRepository<CurriculumToSubject> CurriculumToSubjects { get;  }
        IGenericRepository<LessonPlan> LessonPlans { get;  }
        IGenericRepository<LessonPlanWeakly> LessonPlanWeaklies { get;  }
        void Save();
        Task<IdentityResult> SaveAsync();
    }
}
