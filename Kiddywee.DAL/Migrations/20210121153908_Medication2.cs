using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class Medication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "DailyReportMedications");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "DailyReportMedications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medication",
                table: "DailyReportMedications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "DailyReportMedications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DailyReportMedications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DailyReportMedications");

            migrationBuilder.DropColumn(
                name: "Medication",
                table: "DailyReportMedications");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "DailyReportMedications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DailyReportMedications");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "DailyReportMedications",
                type: "text",
                nullable: true);
        }
    }
}
