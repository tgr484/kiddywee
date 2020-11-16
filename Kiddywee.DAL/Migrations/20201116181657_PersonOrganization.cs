using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class PersonOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_StaffInfoId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "StaffInfo");

            migrationBuilder.DropColumn(
                name: "StaffInfoId1",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_OrganizationId",
                table: "People",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StaffInfoId",
                table: "People",
                column: "StaffInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Organizations_OrganizationId",
                table: "People",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId",
                table: "People",
                column: "StaffInfoId",
                principalTable: "StaffInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Organizations_OrganizationId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_OrganizationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_StaffInfoId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "StaffInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StaffInfoId1",
                table: "People",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_StaffInfoId1",
                table: "People",
                column: "StaffInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId1",
                table: "People",
                column: "StaffInfoId1",
                principalTable: "StaffInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
