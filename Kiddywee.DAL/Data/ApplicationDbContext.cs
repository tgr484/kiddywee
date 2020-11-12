using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        #region Debug Information
        public DbSet<AppUserAction> AppUserActions { get; set; }
        public DbSet<AppError> AppErrors { get; set; }
        #endregion


        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumSubjectGoal> CurriculumSubjectGoals { get; set; }
        public DbSet<CurriculumSubjectGoalHierarchy> CurriculumSubjectGoalHierarchies { get; set; }
        public DbSet<CurriculumToSubject> CurriculumToSubjects { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<LessonPlanWeakly> LessonPlanWeaklies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppError>().ToTable("AppErrors", "log");
            builder.Entity<AppUserAction>().ToTable("AppUserActions", "log");
            base.OnModelCreating(builder);
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
        //    {
        //        new IdentityRole {
        //            Id =  Guid.NewGuid().ToString(),
        //            Name = "Admin",
        //            NormalizedName = "ADMIN"
        //        },
        //        new IdentityRole {
        //            Id =  Guid.NewGuid().ToString(),
        //            Name = "Teacher",
        //            NormalizedName = "TEACHER"
        //        },
        //        new IdentityRole {
        //            Id =  Guid.NewGuid().ToString(),
        //            Name = "Student",
        //            NormalizedName = "STUDENT"
        //        },
        //        new IdentityRole {
        //            Id =  Guid.NewGuid().ToString(),
        //            Name = "Parent",
        //            NormalizedName = "PARENT"
        //        },
        //        new IdentityRole {
        //            Id =  Guid.NewGuid().ToString(),
        //            Name = "GlobalAdmin",
        //            NormalizedName = "GLOBALADMIN"
        //        },
        //    });
        //    base.OnModelCreating(builder);
        //}
    }
}
