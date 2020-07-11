using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class AddedWLsToInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkLogId",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId1",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId10",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId11",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId12",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId13",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId14",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId15",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId16",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId17",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId18",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId19",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId2",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId3",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId4",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId5",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId6",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId7",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId8",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLogId9",
                table: "Invoice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId",
                table: "Invoice",
                column: "WorkLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId1",
                table: "Invoice",
                column: "WorkLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId10",
                table: "Invoice",
                column: "WorkLogId10");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId11",
                table: "Invoice",
                column: "WorkLogId11");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId12",
                table: "Invoice",
                column: "WorkLogId12");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId13",
                table: "Invoice",
                column: "WorkLogId13");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId14",
                table: "Invoice",
                column: "WorkLogId14");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId15",
                table: "Invoice",
                column: "WorkLogId15");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId16",
                table: "Invoice",
                column: "WorkLogId16");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId17",
                table: "Invoice",
                column: "WorkLogId17");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId18",
                table: "Invoice",
                column: "WorkLogId18");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId19",
                table: "Invoice",
                column: "WorkLogId19");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId2",
                table: "Invoice",
                column: "WorkLogId2");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId3",
                table: "Invoice",
                column: "WorkLogId3");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId4",
                table: "Invoice",
                column: "WorkLogId4");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId5",
                table: "Invoice",
                column: "WorkLogId5");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId6",
                table: "Invoice",
                column: "WorkLogId6");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId7",
                table: "Invoice",
                column: "WorkLogId7");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId8",
                table: "Invoice",
                column: "WorkLogId8");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkLogId9",
                table: "Invoice",
                column: "WorkLogId9");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId",
                table: "Invoice",
                column: "WorkLogId",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId1",
                table: "Invoice",
                column: "WorkLogId1",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId10",
                table: "Invoice",
                column: "WorkLogId10",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId11",
                table: "Invoice",
                column: "WorkLogId11",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId12",
                table: "Invoice",
                column: "WorkLogId12",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId13",
                table: "Invoice",
                column: "WorkLogId13",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId14",
                table: "Invoice",
                column: "WorkLogId14",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId15",
                table: "Invoice",
                column: "WorkLogId15",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId16",
                table: "Invoice",
                column: "WorkLogId16",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId17",
                table: "Invoice",
                column: "WorkLogId17",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId18",
                table: "Invoice",
                column: "WorkLogId18",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId19",
                table: "Invoice",
                column: "WorkLogId19",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId2",
                table: "Invoice",
                column: "WorkLogId2",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId3",
                table: "Invoice",
                column: "WorkLogId3",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId4",
                table: "Invoice",
                column: "WorkLogId4",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId5",
                table: "Invoice",
                column: "WorkLogId5",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId6",
                table: "Invoice",
                column: "WorkLogId6",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId7",
                table: "Invoice",
                column: "WorkLogId7",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId8",
                table: "Invoice",
                column: "WorkLogId8",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_WLog_WorkLogId9",
                table: "Invoice",
                column: "WorkLogId9",
                principalTable: "WLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId1",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId10",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId11",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId12",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId13",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId14",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId15",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId16",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId17",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId18",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId19",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId2",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId3",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId4",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId5",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId6",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId7",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId8",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_WLog_WorkLogId9",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId1",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId10",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId11",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId12",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId13",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId14",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId15",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId16",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId17",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId18",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId19",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId2",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId3",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId4",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId5",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId6",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId7",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId8",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_WorkLogId9",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId1",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId10",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId11",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId12",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId13",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId14",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId15",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId16",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId17",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId18",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId19",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId2",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId3",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId4",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId5",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId6",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId7",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId8",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "WorkLogId9",
                table: "Invoice");
        }
    }
}
