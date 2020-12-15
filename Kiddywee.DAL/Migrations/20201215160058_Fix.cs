using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_Organizations_OrgnizationId",
                table: "LessonPlans");

            migrationBuilder.DropIndex(
                name: "IX_LessonPlans_OrgnizationId",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "OrgnizationId",
                table: "LessonPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "LessonPlans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_OrganizationId",
                table: "LessonPlans",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_Organizations_OrganizationId",
                table: "LessonPlans",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_Organizations_OrganizationId",
                table: "LessonPlans");

            migrationBuilder.DropIndex(
                name: "IX_LessonPlans_OrganizationId",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "LessonPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "OrgnizationId",
                table: "LessonPlans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_OrgnizationId",
                table: "LessonPlans",
                column: "OrgnizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_Organizations_OrgnizationId",
                table: "LessonPlans",
                column: "OrgnizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
