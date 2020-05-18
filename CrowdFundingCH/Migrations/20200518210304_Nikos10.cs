using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class Nikos10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserIdId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserIdId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Projects",
                type: "nvarchar(450)",
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
    }
}
