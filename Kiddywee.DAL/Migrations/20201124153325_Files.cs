using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class Files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileData",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "FileExtention",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "FileRealName",
                table: "MedicalInfos");

            migrationBuilder.EnsureSchema(
                name: "files");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "MedicalInfos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Extention = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInfos_FileId",
                table: "MedicalInfos",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInfos_Files_FileId",
                table: "MedicalInfos",
                column: "FileId",
                principalSchema: "files",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInfos_Files_FileId",
                table: "MedicalInfos");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "files");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInfos_FileId",
                table: "MedicalInfos");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "MedicalInfos");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "MedicalInfos",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtention",
                table: "MedicalInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "MedicalInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileRealName",
                table: "MedicalInfos",
                type: "text",
                nullable: true);
        }
    }
}
