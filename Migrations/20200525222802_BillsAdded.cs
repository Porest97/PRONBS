using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class BillsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true),
                    BillingDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    NABLogId = table.Column<int>(nullable: true),
                    NABLogId1 = table.Column<int>(nullable: true),
                    NABLogId2 = table.Column<int>(nullable: true),
                    NABLogId3 = table.Column<int>(nullable: true),
                    NABLogId4 = table.Column<int>(nullable: true),
                    BillingTerms = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    BillStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_BillStatus_BillStatusId",
                        column: x => x.BillStatusId,
                        principalTable: "BillStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId",
                        column: x => x.NABLogId,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId1",
                        column: x => x.NABLogId1,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId2",
                        column: x => x.NABLogId2,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId3",
                        column: x => x.NABLogId3,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId4",
                        column: x => x.NABLogId4,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_BillStatusId",
                table: "Bill",
                column: "BillStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CompanyId",
                table: "Bill",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CompanyId1",
                table: "Bill",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId",
                table: "Bill",
                column: "NABLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId1",
                table: "Bill",
                column: "NABLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId2",
                table: "Bill",
                column: "NABLogId2");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId3",
                table: "Bill",
                column: "NABLogId3");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId4",
                table: "Bill",
                column: "NABLogId4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "BillStatus");
        }
    }
}
