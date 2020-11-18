using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class StaffAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfo_AspNetUsers_CreatedById",
                table: "StaffInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfo_MedicalInfos_MedicalInfoId",
                table: "StaffInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfo_Organizations_OrganizationId",
                table: "StaffInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffTraining_StaffInfo_StaffInfoId",
                table: "StaffTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffInfo",
                table: "StaffInfo");

            migrationBuilder.RenameTable(
                name: "StaffInfo",
                newName: "StaffInfos");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfo_OrganizationId",
                table: "StaffInfos",
                newName: "IX_StaffInfos_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfo_MedicalInfoId",
                table: "StaffInfos",
                newName: "IX_StaffInfos_MedicalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfo_CreatedById",
                table: "StaffInfos",
                newName: "IX_StaffInfos_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffInfos",
                table: "StaffInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_StaffInfos_StaffInfoId",
                table: "People",
                column: "StaffInfoId",
                principalTable: "StaffInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfos_AspNetUsers_CreatedById",
                table: "StaffInfos",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfos_MedicalInfos_MedicalInfoId",
                table: "StaffInfos",
                column: "MedicalInfoId",
                principalTable: "MedicalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfos_Organizations_OrganizationId",
                table: "StaffInfos",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffTraining_StaffInfos_StaffInfoId",
                table: "StaffTraining",
                column: "StaffInfoId",
                principalTable: "StaffInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_StaffInfos_StaffInfoId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfos_AspNetUsers_CreatedById",
                table: "StaffInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfos_MedicalInfos_MedicalInfoId",
                table: "StaffInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInfos_Organizations_OrganizationId",
                table: "StaffInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffTraining_StaffInfos_StaffInfoId",
                table: "StaffTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffInfos",
                table: "StaffInfos");

            migrationBuilder.RenameTable(
                name: "StaffInfos",
                newName: "StaffInfo");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfos_OrganizationId",
                table: "StaffInfo",
                newName: "IX_StaffInfo_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfos_MedicalInfoId",
                table: "StaffInfo",
                newName: "IX_StaffInfo_MedicalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInfos_CreatedById",
                table: "StaffInfo",
                newName: "IX_StaffInfo_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffInfo",
                table: "StaffInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_StaffInfo_StaffInfoId",
                table: "People",
                column: "StaffInfoId",
                principalTable: "StaffInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfo_AspNetUsers_CreatedById",
                table: "StaffInfo",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfo_MedicalInfos_MedicalInfoId",
                table: "StaffInfo",
                column: "MedicalInfoId",
                principalTable: "MedicalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInfo_Organizations_OrganizationId",
                table: "StaffInfo",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffTraining_StaffInfo_StaffInfoId",
                table: "StaffTraining",
                column: "StaffInfoId",
                principalTable: "StaffInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
