using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingAPI.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_MyUsers_MyUserId",
                table: "MyUsers");

            migrationBuilder.DropIndex(
                name: "IX_MyUsers_MyUserId",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "MyUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "MyUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_MyUserId",
                table: "MyUsers",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_MyUsers_MyUserId",
                table: "MyUsers",
                column: "MyUserId",
                principalTable: "MyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
