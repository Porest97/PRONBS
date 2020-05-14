using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRONBS.Migrations
{
    public partial class ProjectsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferIdenifyer",
                table: "Offer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    ExtraPeople = table.Column<string>(nullable: true),
                    OfferId = table.Column<int>(nullable: true),
                    OfferId1 = table.Column<int>(nullable: true),
                    OfferId2 = table.Column<int>(nullable: true),
                    OfferId3 = table.Column<int>(nullable: true),
                    OfferId4 = table.Column<int>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectStart = table.Column<DateTime>(nullable: true),
                    ProjectEnd = table.Column<DateTime>(nullable: true),
                    ProjectTypeId = table.Column<int>(nullable: true),
                    ProjectStatusId = table.Column<int>(nullable: true),
                    ProjectLog = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Offer_OfferId1",
                        column: x => x.OfferId1,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Offer_OfferId2",
                        column: x => x.OfferId2,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Offer_OfferId3",
                        column: x => x.OfferId3,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Offer_OfferId4",
                        column: x => x.OfferId4,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_ProjectType_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferId",
                table: "Project",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferId1",
                table: "Project",
                column: "OfferId1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferId2",
                table: "Project",
                column: "OfferId2");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferId3",
                table: "Project",
                column: "OfferId3");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OfferId4",
                table: "Project",
                column: "OfferId4");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PersonId",
                table: "Project",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PersonId1",
                table: "Project",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectTypeId",
                table: "Project",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SiteId",
                table: "Project",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.DropColumn(
                name: "OfferIdenifyer",
                table: "Offer");
        }
    }
}
