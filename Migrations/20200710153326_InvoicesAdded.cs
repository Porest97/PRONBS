using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class InvoicesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceNumber = table.Column<int>(nullable: true),
                    OCRNumber = table.Column<int>(nullable: true),
                    CustomerNumber = table.Column<string>(nullable: true),
                    TermsOfDelivery = table.Column<string>(nullable: true),
                    YourVATNumber = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PaymentConditions = table.Column<string>(nullable: true),
                    InvoiceDueDate = table.Column<DateTime>(nullable: false),
                    PenaltyInetrest = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId1",
                table: "Invoice",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PersonId",
                table: "Invoice",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
