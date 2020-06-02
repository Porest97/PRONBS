using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class PlansAndStagesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    StageStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage_StageStatus_StageStatusId",
                        column: x => x.StageStatusId,
                        principalTable: "StageStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDescription = table.Column<string>(nullable: true),
                    IncidentId = table.Column<int>(nullable: true),
                    StageId = table.Column<int>(nullable: true),
                    StageId1 = table.Column<int>(nullable: true),
                    StageId2 = table.Column<int>(nullable: true),
                    StageId3 = table.Column<int>(nullable: true),
                    StageId4 = table.Column<int>(nullable: true),
                    StageId5 = table.Column<int>(nullable: true),
                    PlanStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_PlanStatus_PlanStatusId",
                        column: x => x.PlanStatusId,
                        principalTable: "PlanStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId1",
                        column: x => x.StageId1,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId2",
                        column: x => x.StageId2,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId3",
                        column: x => x.StageId3,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId4",
                        column: x => x.StageId4,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Stage_StageId5",
                        column: x => x.StageId5,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_IncidentId",
                table: "Plan",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_PlanStatusId",
                table: "Plan",
                column: "PlanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId",
                table: "Plan",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId1",
                table: "Plan",
                column: "StageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId2",
                table: "Plan",
                column: "StageId2");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId3",
                table: "Plan",
                column: "StageId3");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId4",
                table: "Plan",
                column: "StageId4");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StageId5",
                table: "Plan",
                column: "StageId5");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_StageStatusId",
                table: "Stage",
                column: "StageStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "PlanStatus");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "StageStatus");
        }
    }
}
