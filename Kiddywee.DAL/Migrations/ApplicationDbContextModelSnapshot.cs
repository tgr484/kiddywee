﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Kiddywee.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kiddywee.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kiddywee.DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("PersonId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<List<int>>("DailyReportTypes")
                        .HasColumnType("integer[]");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EnrollmentSpots")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<int>("StageType")
                        .HasColumnType("integer");

                    b.Property<int?>("TeacherStudentRatio")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uuid");

                    b.Property<int>("ContactType")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<Guid?>("GuardianId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("PhoneHome")
                        .HasColumnType("text");

                    b.Property<string>("PhoneMobile")
                        .HasColumnType("text");

                    b.Property<string>("PhoneWork")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GuardianId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Curriculum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OrgnizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrgnizationId");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumSubjectGoal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<Guid>("CurriculumToSubjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LearningStandardIdentifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurriculumToSubjectId");

                    b.ToTable("CurriculumSubjectGoals");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumSubjectGoalHierarchy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<Guid?>("CurriculumSubjectGoalHierarchyParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurriculumSubjectGoalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurriculumSubjectGoalHierarchyParentId");

                    b.HasIndex("CurriculumSubjectGoalId");

                    b.ToTable("CurriculumSubjectGoalHierarchies");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumToSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<Guid>("CurriculumId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurriculumId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CurriculumToSubjects");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.LessonPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<Guid?>("CurriculumToSubjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<Guid>("OrgnizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("TeacherNotes")
                        .HasColumnType("text");

                    b.Property<string>("Theme")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurriculumToSubjectId");

                    b.HasIndex("OrgnizationId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LessonPlans");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.LessonPlanWeakly", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<Guid?>("CurriculumToSubjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<Guid>("OrgnizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("TeacherNotes")
                        .HasColumnType("text");

                    b.Property<string>("Theme")
                        .HasColumnType("text");

                    b.Property<DateTime>("WeekDateSunday")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurriculumToSubjectId");

                    b.HasIndex("OrgnizationId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LessonPlanWeaklies");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OrgnizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrgnizationId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.ApplicationUser", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Class", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Organization")
                        .WithMany("Classes")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Contact", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Person", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.Person", "Guardian")
                        .WithMany()
                        .HasForeignKey("GuardianId");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Curriculum", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Class", "Class")
                        .WithMany("Curriculums")
                        .HasForeignKey("ClassId");

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Orgnization")
                        .WithMany()
                        .HasForeignKey("OrgnizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumSubjectGoal", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.CurriculumToSubject", "CurriculumToSubject")
                        .WithMany()
                        .HasForeignKey("CurriculumToSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumSubjectGoalHierarchy", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.CurriculumSubjectGoalHierarchy", "CurriculumSubjectGoalHierarchyParent")
                        .WithMany()
                        .HasForeignKey("CurriculumSubjectGoalHierarchyParentId");

                    b.HasOne("Kiddywee.DAL.Models.CurriculumSubjectGoal", "CurriculumSubjectGoal")
                        .WithMany()
                        .HasForeignKey("CurriculumSubjectGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.CurriculumToSubject", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.LessonPlan", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.CurriculumToSubject", "CurriculumToSubject")
                        .WithMany()
                        .HasForeignKey("CurriculumToSubjectId");

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Orgnization")
                        .WithMany()
                        .HasForeignKey("OrgnizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.LessonPlanWeakly", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.CurriculumToSubject", "CurriculumToSubject")
                        .WithMany()
                        .HasForeignKey("CurriculumToSubjectId");

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Orgnization")
                        .WithMany()
                        .HasForeignKey("OrgnizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Organization", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("Kiddywee.DAL.Models.Subject", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.Class", "Class")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassId");

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Kiddywee.DAL.Models.Organization", "Orgnization")
                        .WithMany("Subjects")
                        .HasForeignKey("OrgnizationId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Kiddywee.DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
