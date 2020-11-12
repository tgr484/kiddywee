using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class Logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.CreateTable(
                name: "AppErrors",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppErrors_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserActions",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserActions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppErrors_CreatedById",
                schema: "log",
                table: "AppErrors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserActions_CreatedById",
                schema: "log",
                table: "AppUserActions",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppErrors",
                schema: "log");

            migrationBuilder.DropTable(
                name: "AppUserActions",
                schema: "log");
        }
    }
}
