using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class PersonToClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInfos_Classes_ClassId",
                table: "ChildInfos");

            migrationBuilder.DropIndex(
                name: "IX_ChildInfos_ClassId",
                table: "ChildInfos");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "ChildInfos");

            migrationBuilder.CreateTable(
                name: "PersonToClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonToClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonToClasses_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToClasses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonToClasses_ClassId",
                table: "PersonToClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToClasses_CreatedById",
                table: "PersonToClasses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToClasses_PersonId",
                table: "PersonToClasses",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonToClasses");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "ChildInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_ClassId",
                table: "ChildInfos",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInfos_Classes_ClassId",
                table: "ChildInfos",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
