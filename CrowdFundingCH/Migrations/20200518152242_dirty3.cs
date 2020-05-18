using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class dirty3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackedProject");

            migrationBuilder.CreateTable(
                name: "Fundeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllUsersId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AllUsersId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funds_AspNetUsers_AllUsersId",
                        column: x => x.AllUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funds_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
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

            migrationBuilder.CreateIndex(
                name: "IX_Funds_AllUsersId",
                table: "Funds",
                column: "AllUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Funds_ProjectId",
                table: "Funds",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundeds");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.CreateTable(
                name: "BackedProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackedProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackedProject_AspNetUsers_AllUsersId",
                        column: x => x.AllUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackedProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackedProject_AllUsersId",
                table: "BackedProject",
                column: "AllUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BackedProject_ProjectId",
                table: "BackedProject",
                column: "ProjectId");
        }
    }
}
