using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundeds");

            migrationBuilder.CreateTable(
                name: "BackedProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllUsersId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackedProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackedProjects_AspNetUsers_AllUsersId",
                        column: x => x.AllUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackedProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    MultimediaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.MultimediaId);
                    table.ForeignKey(
                        name: "FK_Multimedia_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackedProjects_AllUsersId",
                table: "BackedProjects",
                column: "AllUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BackedProjects_ProjectId",
                table: "BackedProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_ProjectId",
                table: "Multimedia",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackedProjects");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.CreateTable(
                name: "Fundeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fundeds_AspNetUsers_AllUsersId",
                        column: x => x.AllUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fundeds_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fundeds_AllUsersId",
                table: "Fundeds",
                column: "AllUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Fundeds_ProjectId",
                table: "Fundeds",
                column: "ProjectId");
        }
    }
}
