using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingAPI.Migrations
{
    public partial class decimals2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectTargetAmountTostring",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectTargetAmountTostring",
                table: "Project");
        }
    }
}
