using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class AddedEmployeeInTimeReportsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "TimeReport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_PersonId1",
                table: "TimeReport",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReport_Person_PersonId1",
                table: "TimeReport",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeReport_Person_PersonId1",
                table: "TimeReport");

            migrationBuilder.DropIndex(
                name: "IX_TimeReport_PersonId1",
                table: "TimeReport");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "TimeReport");
        }
    }
}
