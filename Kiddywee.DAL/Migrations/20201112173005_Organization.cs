using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class Organization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StageType = table.Column<int>(nullable: false),
                    DailyReportTypes = table.Column<List<int>>(nullable: true),
                    EnrollmentSpots = table.Column<int>(nullable: true),
                    TeacherStudentRatio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    OrgnizationId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curriculums_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curriculums_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curriculums_Organizations_OrgnizationId",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrgnizationId = table.Column<Guid>(nullable: true),
                    ClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Organizations_OrgnizationId",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumToSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    CurriculumId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumToSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumToSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumToSubjects_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumToSubjects_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumToSubjects_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumToSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumSubjectGoals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LearningStandardIdentifier = table.Column<string>(nullable: true),
                    CurriculumToSubjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumSubjectGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjectGoals_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjectGoals_CurriculumToSubjects_CurriculumToSub~",
                        column: x => x.CurriculumToSubjectId,
                        principalTable: "CurriculumToSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    OrgnizationId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    CurriculumToSubjectId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TeacherNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonPlans_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlans_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlans_CurriculumToSubjects_CurriculumToSubjectId",
                        column: x => x.CurriculumToSubjectId,
                        principalTable: "CurriculumToSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlans_Organizations_OrgnizationId",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPlans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlanWeaklies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    OrgnizationId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    CurriculumToSubjectId = table.Column<Guid>(nullable: true),
                    WeekDateSunday = table.Column<DateTime>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TeacherNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlanWeaklies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonPlanWeaklies_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlanWeaklies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlanWeaklies_CurriculumToSubjects_CurriculumToSubject~",
                        column: x => x.CurriculumToSubjectId,
                        principalTable: "CurriculumToSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonPlanWeaklies_Organizations_OrgnizationId",
                        column: x => x.OrgnizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPlanWeaklies_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumSubjectGoalHierarchies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    CurriculumSubjectGoalId = table.Column<Guid>(nullable: false),
                    CurriculumSubjectGoalHierarchyParentId = table.Column<Guid>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumSubjectGoalHierarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjectGoalHierarchies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjectGoalHierarchies_CurriculumSubjectGoalHiera~",
                        column: x => x.CurriculumSubjectGoalHierarchyParentId,
                        principalTable: "CurriculumSubjectGoalHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjectGoalHierarchies_CurriculumSubjectGoals_Cur~",
                        column: x => x.CurriculumSubjectGoalId,
                        principalTable: "CurriculumSubjectGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreatedById",
                table: "Contacts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CreatedById",
                table: "Classes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_OrganizationId",
                table: "Classes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_ClassId",
                table: "Curriculums",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_CreatedById",
                table: "Curriculums",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_OrgnizationId",
                table: "Curriculums",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjectGoalHierarchies_CreatedById",
                table: "CurriculumSubjectGoalHierarchies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjectGoalHierarchies_CurriculumSubjectGoalHiera~",
                table: "CurriculumSubjectGoalHierarchies",
                column: "CurriculumSubjectGoalHierarchyParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjectGoalHierarchies_CurriculumSubjectGoalId",
                table: "CurriculumSubjectGoalHierarchies",
                column: "CurriculumSubjectGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjectGoals_CreatedById",
                table: "CurriculumSubjectGoals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjectGoals_CurriculumToSubjectId",
                table: "CurriculumSubjectGoals",
                column: "CurriculumToSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumToSubjects_ClassId",
                table: "CurriculumToSubjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumToSubjects_CreatedById",
                table: "CurriculumToSubjects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumToSubjects_CurriculumId",
                table: "CurriculumToSubjects",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumToSubjects_OrganizationId",
                table: "CurriculumToSubjects",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumToSubjects_SubjectId",
                table: "CurriculumToSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_ClassId",
                table: "LessonPlans",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_CreatedById",
                table: "LessonPlans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_CurriculumToSubjectId",
                table: "LessonPlans",
                column: "CurriculumToSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_OrgnizationId",
                table: "LessonPlans",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_SubjectId",
                table: "LessonPlans",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanWeaklies_ClassId",
                table: "LessonPlanWeaklies",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanWeaklies_CreatedById",
                table: "LessonPlanWeaklies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanWeaklies_CurriculumToSubjectId",
                table: "LessonPlanWeaklies",
                column: "CurriculumToSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanWeaklies_OrgnizationId",
                table: "LessonPlanWeaklies",
                column: "OrgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanWeaklies_SubjectId",
                table: "LessonPlanWeaklies",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatedById",
                table: "Organizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CreatedById",
                table: "Subjects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_OrgnizationId",
                table: "Subjects",
                column: "OrgnizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_CreatedById",
                table: "Contacts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_CreatedById",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "CurriculumSubjectGoalHierarchies");

            migrationBuilder.DropTable(
                name: "LessonPlans");

            migrationBuilder.DropTable(
                name: "LessonPlanWeaklies");

            migrationBuilder.DropTable(
                name: "CurriculumSubjectGoals");

            migrationBuilder.DropTable(
                name: "CurriculumToSubjects");

            migrationBuilder.DropTable(
                name: "Curriculums");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CreatedById",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Contacts");
        }
    }
}
