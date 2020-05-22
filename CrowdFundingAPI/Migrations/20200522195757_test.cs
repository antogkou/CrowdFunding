using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_First_Name = table.Column<string>(maxLength: 255, nullable: false),
                    user_Last_Name = table.Column<string>(nullable: true),
                    user_Email = table.Column<string>(maxLength: 255, nullable: false),
                    user_Phone = table.Column<string>(nullable: true),
                    user_VAT = table.Column<string>(nullable: true),
                    UserDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    ProjectTitle = table.Column<string>(maxLength: 255, nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectTargetAmount = table.Column<decimal>(type: "decimal(18,4)", maxLength: 20, nullable: false),
                    ProjectCurrentAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProjectViewsCounter = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    EndingDate = table.Column<DateTimeOffset>(nullable: false),
                    ProjectCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    MultimediaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    MultimediaURL = table.Column<string>(nullable: false),
                    MultimediaType = table.Column<int>(nullable: false),
                    MultimediaDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.MultimediaId);
                    table.ForeignKey(
                        name: "FK_Multimedia_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pledge",
                columns: table => new
                {
                    PledgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    PledgeTitle = table.Column<string>(maxLength: 255, nullable: false),
                    PledgeDescription = table.Column<string>(nullable: true),
                    PledgePrice = table.Column<decimal>(maxLength: 20, nullable: false),
                    PledgeReward = table.Column<string>(nullable: true),
                    PledgeDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pledge", x => x.PledgeId);
                    table.ForeignKey(
                        name: "FK_Pledge_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    PostTitle = table.Column<string>(maxLength: 255, nullable: false),
                    PostExcerpt = table.Column<string>(nullable: true),
                    PostDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackedPledges",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PledgeId = table.Column<int>(nullable: false),
                    created_BackedPledge = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackedPledges", x => new { x.UserId, x.PledgeId });
                    table.ForeignKey(
                        name: "FK_BackedPledges_Pledge_PledgeId",
                        column: x => x.PledgeId,
                        principalTable: "Pledge",
                        principalColumn: "PledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackedPledges_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackedPledges_PledgeId",
                table: "BackedPledges",
                column: "PledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_ProjectId",
                table: "Multimedia",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pledge_ProjectId",
                table: "Pledge",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ProjectId",
                table: "Post",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_Last_Name",
                table: "User",
                column: "user_Last_Name",
                unique: true,
                filter: "[user_Last_Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackedPledges");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Pledge");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
