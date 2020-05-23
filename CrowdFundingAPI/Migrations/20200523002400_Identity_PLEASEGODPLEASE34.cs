using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingAPI.Migrations
{
    public partial class Identity_PLEASEGODPLEASE34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_First_Name",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "user_Last_Name",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "user_VAT",
                table: "MyUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_First_Name",
                table: "MyUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_Last_Name",
                table: "MyUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_VAT",
                table: "MyUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
