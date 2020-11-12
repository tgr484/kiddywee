using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class ChildInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                schema: "log",
                table: "AppErrors");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                schema: "log",
                table: "AppErrors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InnerException",
                schema: "log",
                table: "AppErrors",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildInfoId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildInfoId1",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileExtention = table.Column<string>(nullable: true),
                    FileRealName = table.Column<string>(nullable: true),
                    FileData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalInfos_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NextMedical = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    WeaklySchedule = table.Column<List<int>>(nullable: true),
                    DailySchedule = table.Column<List<int>>(nullable: true),
                    ClassId = table.Column<Guid>(nullable: false),
                    CurriculumId = table.Column<Guid>(nullable: true),
                    PipeLineType = table.Column<int>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    MedicalInfoId = table.Column<Guid>(nullable: true),
                    ImmunisationId = table.Column<Guid>(nullable: true),
                    Allergies = table.Column<bool>(nullable: false),
                    AllergiesNotes = table.Column<string>(nullable: true),
                    PictureAuthorized = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildInfos_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildInfos_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildInfos_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildInfos_MedicalInfos_ImmunisationId",
                        column: x => x.ImmunisationId,
                        principalTable: "MedicalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildInfos_MedicalInfos_MedicalInfoId",
                        column: x => x.MedicalInfoId,
                        principalTable: "MedicalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ChildInfoId1",
                table: "People",
                column: "ChildInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_ClassId",
                table: "ChildInfos",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_CreatedById",
                table: "ChildInfos",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_CurriculumId",
                table: "ChildInfos",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_ImmunisationId",
                table: "ChildInfos",
                column: "ImmunisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_MedicalInfoId",
                table: "ChildInfos",
                column: "MedicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInfos_CreatedById",
                table: "MedicalInfos",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId1",
                table: "People",
                column: "ChildInfoId1",
                principalTable: "ChildInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId1",
                table: "People");

            migrationBuilder.DropTable(
                name: "ChildInfos");

            migrationBuilder.DropTable(
                name: "MedicalInfos");

            migrationBuilder.DropIndex(
                name: "IX_People_ChildInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Exception",
                schema: "log",
                table: "AppErrors");

            migrationBuilder.DropColumn(
                name: "InnerException",
                schema: "log",
                table: "AppErrors");

            migrationBuilder.DropColumn(
                name: "ChildInfoId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ChildInfoId1",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "log",
                table: "AppErrors",
                type: "text",
                nullable: true);
        }
    }
}
