using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class TimeReportsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeReportId",
                table: "WLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeReportId",
                table: "NABLog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeReportName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTimeCreated = table.Column<DateTime>(nullable: true),
                    DateTimeFrom = table.Column<DateTime>(nullable: true),
                    DateTimeTo = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WLog_TimeReportId",
                table: "WLog",
                column: "TimeReportId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_TimeReportId",
                table: "NABLog",
                column: "TimeReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_PersonId",
                table: "TimeReport",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_NABLog_TimeReport_TimeReportId",
                table: "NABLog",
                column: "TimeReportId",
                principalTable: "TimeReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WLog_TimeReport_TimeReportId",
                table: "WLog",
                column: "TimeReportId",
                principalTable: "TimeReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NABLog_TimeReport_TimeReportId",
                table: "NABLog");

            migrationBuilder.DropForeignKey(
                name: "FK_WLog_TimeReport_TimeReportId",
                table: "WLog");

            migrationBuilder.DropTable(
                name: "TimeReport");

            migrationBuilder.DropIndex(
                name: "IX_WLog_TimeReportId",
                table: "WLog");

            migrationBuilder.DropIndex(
                name: "IX_NABLog_TimeReportId",
                table: "NABLog");

            migrationBuilder.DropColumn(
                name: "TimeReportId",
                table: "WLog");

            migrationBuilder.DropColumn(
                name: "TimeReportId",
                table: "NABLog");
        }
    }
}
