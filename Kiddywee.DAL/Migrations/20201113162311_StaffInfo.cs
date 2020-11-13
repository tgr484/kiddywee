using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class StaffInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ChildInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ChildInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ChildInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffInfoId",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StaffInfoId1",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InfoId",
                table: "MedicalInfos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "PersonToContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonToContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonToContacts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonToContacts_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    StaffRole = table.Column<int>(nullable: false),
                    Schedule = table.Column<List<int>>(nullable: true),
                    MedicalInfoId = table.Column<Guid>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberDigitPin = table.Column<int>(nullable: false),
                    PromedicalFormDueDate = table.Column<DateTime>(nullable: true),
                    EmploymentType = table.Column<int>(nullable: false),
                    CheckInTime = table.Column<string>(nullable: true),
                    CheckOutTime = table.Column<string>(nullable: true),
                    SalaryType = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    ChildAbuseCert = table.Column<DateTime>(nullable: true),
                    FirstAidTraining = table.Column<DateTime>(nullable: true),
                    Scr = table.Column<DateTime>(nullable: true),
                    FingerPrinting = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffInfo_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffInfo_MedicalInfos_MedicalInfoId",
                        column: x => x.MedicalInfoId,
                        principalTable: "MedicalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffInfo_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffTraining",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    StaffInfoId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffTraining_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffTraining_StaffInfo_StaffInfoId",
                        column: x => x.StaffInfoId,
                        principalTable: "StaffInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ChildInfoId",
                table: "People",
                column: "ChildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StaffInfoId1",
                table: "People",
                column: "StaffInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToContacts_ContactId",
                table: "PersonToContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToContacts_CreatedById",
                table: "PersonToContacts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PersonToContacts_PersonId",
                table: "PersonToContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfo_CreatedById",
                table: "StaffInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfo_MedicalInfoId",
                table: "StaffInfo",
                column: "MedicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfo_OrganizationId",
                table: "StaffInfo",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTraining_CreatedById",
                table: "StaffTraining",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTraining_StaffInfoId",
                table: "StaffTraining",
                column: "StaffInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts",
                column: "ChildId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId",
                table: "People",
                column: "ChildInfoId",
                principalTable: "ChildInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId1",
                table: "People",
                column: "StaffInfoId1",
                principalTable: "StaffInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId1",
                table: "People");

            migrationBuilder.DropTable(
                name: "PersonToContacts");

            migrationBuilder.DropTable(
                name: "StaffTraining");

            migrationBuilder.DropTable(
                name: "StaffInfo");

            migrationBuilder.DropIndex(
                name: "IX_People_ChildInfoId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_StaffInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "StaffInfoId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "StaffInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "MedicalInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildInfoId1",
                table: "People",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Contacts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "ChildInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_People_ChildInfoId1",
                table: "People",
                column: "ChildInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_People_ChildId",
                table: "Contacts",
                column: "ChildId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_ChildInfos_ChildInfoId1",
                table: "People",
                column: "ChildInfoId1",
                principalTable: "ChildInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
