using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class DailyReportNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReports");

            migrationBuilder.CreateTable(
                name: "DailyReportNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportNotes_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReportNotes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportNotes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReportNotes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportNotes_ClassId",
                table: "DailyReportNotes",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportNotes_CreatedById",
                table: "DailyReportNotes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportNotes_OrganizationId",
                table: "DailyReportNotes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportNotes_PersonId",
                table: "DailyReportNotes",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReportNotes");

            migrationBuilder.CreateTable(
                name: "DailyReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Report = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReports_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReports_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReports_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReports_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_ClassId",
                table: "DailyReports",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_CreatedById",
                table: "DailyReports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_OrganizationId",
                table: "DailyReports",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_PersonId",
                table: "DailyReports",
                column: "PersonId");
        }
    }
}
