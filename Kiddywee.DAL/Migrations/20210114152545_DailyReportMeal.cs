using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class DailyReportMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyReportMeals",
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
                    MealType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportMeals_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReportMeals_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportMeals_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReportMeals_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportFoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DailyReportMealId = table.Column<Guid>(nullable: false),
                    FoodType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportFoods_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportFoods_DailyReportMeals_DailyReportMealId",
                        column: x => x.DailyReportMealId,
                        principalTable: "DailyReportMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportFoods_CreatedById",
                table: "DailyReportFoods",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportFoods_DailyReportMealId",
                table: "DailyReportFoods",
                column: "DailyReportMealId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMeals_ClassId",
                table: "DailyReportMeals",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMeals_CreatedById",
                table: "DailyReportMeals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMeals_OrganizationId",
                table: "DailyReportMeals",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMeals_PersonId",
                table: "DailyReportMeals",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReportFoods");

            migrationBuilder.DropTable(
                name: "DailyReportMeals");
        }
    }
}
