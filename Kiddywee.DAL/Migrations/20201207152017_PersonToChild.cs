using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class PersonToChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_People_GuardianId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ChildId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_GuardianId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonToChild",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    ChildId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonToChild_People_ChildId",
                        column: x => x.ChildId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonToChild_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToChild_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonToChild_ChildId",
                table: "PersonToChild",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToChild_CreatedById",
                table: "PersonToChild",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToChild_PersonId",
                table: "PersonToChild",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonToChild");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Contacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianId",
                table: "Contacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ChildId",
                table: "Contacts",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GuardianId",
                table: "Contacts",
                column: "GuardianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts",
                column: "ChildId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_People_GuardianId",
                table: "Contacts",
                column: "GuardianId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
