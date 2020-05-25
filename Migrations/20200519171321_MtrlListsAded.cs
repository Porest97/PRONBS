using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class MtrlListsAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MtrlListId",
                table: "Incident",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MtrlList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Item1 = table.Column<string>(nullable: true),
                    Item2 = table.Column<string>(nullable: true),
                    Item3 = table.Column<string>(nullable: true),
                    Item4 = table.Column<string>(nullable: true),
                    Item5 = table.Column<string>(nullable: true),
                    Item6 = table.Column<string>(nullable: true),
                    Item7 = table.Column<string>(nullable: true),
                    Item8 = table.Column<string>(nullable: true),
                    Item9 = table.Column<string>(nullable: true),
                    Item10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtrlList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incident_MtrlListId",
                table: "Incident",
                column: "MtrlListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_MtrlList_MtrlListId",
                table: "Incident",
                column: "MtrlListId",
                principalTable: "MtrlList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_MtrlList_MtrlListId",
                table: "Incident");

            migrationBuilder.DropTable(
                name: "MtrlList");

            migrationBuilder.DropIndex(
                name: "IX_Incident_MtrlListId",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "MtrlListId",
                table: "Incident");
        }
    }
}
