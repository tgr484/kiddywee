using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class DailyReportMeal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "DailyReportFoods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "DailyReportFoods");
        }
    }
}
