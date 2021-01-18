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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        #region Debug Information
        public DbSet<AppUserAction> AppUserActions { get; set; }
        public DbSet<AppError> AppErrors { get; set; }
        #endregion 

        public DbSet<Person> People { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ChildInfo> ChildInfos { get; set; }
        public DbSet<StaffInfo> StaffInfos { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PersonToContact> PersonToContacts { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumSubjectGoal> CurriculumSubjectGoals { get; set; }
        public DbSet<CurriculumSubjectGoalHierarchy> CurriculumSubjectGoalHierarchies { get; set; }
        public DbSet<CurriculumToSubject> CurriculumToSubjects { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<LessonPlanWeakly> LessonPlanWeaklies { get; set; }

        public DbSet<PersonToClass> PersonToClasses { get; set; }
        public DbSet<PersonToChild> PersonToChildren { get; set; }
        public DbSet<DailyReportNote> DailyReportNotes { get; set; }
        public DbSet<DailyReportNap> DailyReportNaps { get; set; }
        public DbSet<DailyReportMeal> DailyReportMeals { get; set; }
        public DbSet<DailyReportFood> DailyReportFoods { get; set; }
        public DbSet<DailyReportBathroom> DailyReportBathrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppError>().ToTable("AppErrors", "log");
            builder.Entity<AppUserAction>().ToTable("AppUserActions", "log");

            builder.Entity<Person>(entity =>
                                   entity.HasMany(p => p.PersonToChildren)
                                          .WithOne(d => d.Person)
                                          .HasForeignKey(d => d.PersonId));
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
