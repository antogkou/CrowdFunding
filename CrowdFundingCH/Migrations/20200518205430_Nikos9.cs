using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class Nikos9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AllUsersId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AllUsersId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AllUsersId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectCategoryId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCategory",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserIdId",
                table: "Projects",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UserIdId",
                table: "Projects",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserIdId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserIdId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectCategory",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "AllUsersId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectCategoryId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AllUsersId",
                table: "Projects",
                column: "AllUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AllUsersId",
                table: "Projects",
                column: "AllUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
