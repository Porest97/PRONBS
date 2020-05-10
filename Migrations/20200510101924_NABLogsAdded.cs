using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class NABLogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NABLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NABLogStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NABLogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NABLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentId = table.Column<int>(nullable: true),
                    DateTimeStarted = table.Column<DateTime>(nullable: false),
                    DateTimeEnded = table.Column<DateTime>(nullable: false),
                    LogNotes = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    WLogId = table.Column<int>(nullable: true),
                    NABLogStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NABLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NABLog_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NABLog_NABLogStatus_NABLogStatusId",
                        column: x => x.NABLogStatusId,
                        principalTable: "NABLogStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NABLog_WLog_WLogId",
                        column: x => x.WLogId,
                        principalTable: "WLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_IncidentId",
                table: "NABLog",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_NABLogStatusId",
                table: "NABLog",
                column: "NABLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_WLogId",
                table: "NABLog",
                column: "WLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NABLog");

            migrationBuilder.DropTable(
                name: "NABLogStatus");
        }
    }
}
