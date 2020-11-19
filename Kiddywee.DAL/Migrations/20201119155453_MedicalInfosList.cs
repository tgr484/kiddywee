using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class MedicalInfosList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInfos_MedicalInfos_ImmunisationId",
                table: "ChildInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildInfos_MedicalInfos_MedicalInfoId",
                table: "ChildInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfos_MedicalInfos_MedicalInfoId",
                table: "StaffInfos");

            migrationBuilder.DropIndex(
                name: "IX_StaffInfos_MedicalInfoId",
                table: "StaffInfos");

            migrationBuilder.DropIndex(
                name: "IX_ChildInfos_ImmunisationId",
                table: "ChildInfos");

            migrationBuilder.DropIndex(
                name: "IX_ChildInfos_MedicalInfoId",
                table: "ChildInfos");

            migrationBuilder.DropColumn(
                name: "MedicalInfoId",
                table: "StaffInfos");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "ImmunisationId",
                table: "ChildInfos");

            migrationBuilder.DropColumn(
                name: "MedicalInfoId",
                table: "ChildInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "MedicalInfos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Immunizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileExtention = table.Column<string>(nullable: true),
                    FileRealName = table.Column<string>(nullable: true),
                    FileData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Immunizations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Immunizations_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInfos_PersonId",
                table: "MedicalInfos",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Immunizations_CreatedById",
                table: "Immunizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Immunizations_PersonId",
                table: "Immunizations",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInfos_People_PersonId",
                table: "MedicalInfos",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInfos_People_PersonId",
                table: "MedicalInfos");

            migrationBuilder.DropTable(
                name: "Immunizations");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInfos_PersonId",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MedicalInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalInfoId",
                table: "StaffInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InfoId",
                table: "MedicalInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImmunisationId",
                table: "ChildInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalInfoId",
                table: "ChildInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfos_MedicalInfoId",
                table: "StaffInfos",
                column: "MedicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_ImmunisationId",
                table: "ChildInfos",
                column: "ImmunisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInfos_MedicalInfoId",
                table: "ChildInfos",
                column: "MedicalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInfos_MedicalInfos_ImmunisationId",
                table: "ChildInfos",
                column: "ImmunisationId",
                principalTable: "MedicalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInfos_MedicalInfos_MedicalInfoId",
                table: "ChildInfos",
                column: "MedicalInfoId",
                principalTable: "MedicalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfos_MedicalInfos_MedicalInfoId",
                table: "StaffInfos",
                column: "MedicalInfoId",
                principalTable: "MedicalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
