using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class TesAndSubModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Hours = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Mtr = table.Column<double>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    TotalHours = table.Column<double>(nullable: false),
                    TotalMtr = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    SubModelId = table.Column<int>(nullable: true),
                    SubModelId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestModel_SubModel_SubModelId",
                        column: x => x.SubModelId,
                        principalTable: "SubModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestModel_SubModel_SubModelId1",
                        column: x => x.SubModelId1,
                        principalTable: "SubModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestModel_SubModelId",
                table: "TestModel",
                column: "SubModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TestModel_SubModelId1",
                table: "TestModel",
                column: "SubModelId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.DropTable(
                name: "SubModel");
        }
    }
}
