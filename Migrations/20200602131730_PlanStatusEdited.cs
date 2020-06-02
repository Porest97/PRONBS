using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class PlanStatusEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlantatusName",
                table: "PlanStatus");

            migrationBuilder.AddColumn<string>(
                name: "PlanStatusName",
                table: "PlanStatus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanStatusName",
                table: "PlanStatus");

            migrationBuilder.AddColumn<string>(
                name: "PlantatusName",
                table: "PlanStatus",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
