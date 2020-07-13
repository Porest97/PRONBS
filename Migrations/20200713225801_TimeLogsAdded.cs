using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class TimeLogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeLogStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentId = table.Column<int>(nullable: true),
                    DateTimeStarted = table.Column<DateTime>(nullable: true),
                    DateTimeEnded = table.Column<DateTime>(nullable: true),
                    LogNotes = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    WLogId = table.Column<int>(nullable: true),
                    TimeLogStatusId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLog_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_TimeLogStatus_TimeLogStatusId",
                        column: x => x.TimeLogStatusId,
                        principalTable: "TimeLogStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_WLog_WLogId",
                        column: x => x.WLogId,
                        principalTable: "WLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_IncidentId",
                table: "TimeLog",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_PersonId",
                table: "TimeLog",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_TimeLogStatusId",
                table: "TimeLog",
                column: "TimeLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_WLogId",
                table: "TimeLog",
                column: "WLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLog");

            migrationBuilder.DropTable(
                name: "TimeLogStatus");
        }
    }
}
