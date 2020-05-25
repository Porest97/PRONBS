using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class EmployeeToWLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "WLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WLog_PersonId",
                table: "WLog",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_WLog_Person_PersonId",
                table: "WLog",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WLog_Person_PersonId",
                table: "WLog");

            migrationBuilder.DropIndex(
                name: "IX_WLog_PersonId",
                table: "WLog");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "WLog");
        }
    }
}
