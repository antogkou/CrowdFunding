using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class ant3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategorys_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategorys",
                table: "ProjectCategorys");

            migrationBuilder.RenameTable(
                name: "ProjectCategorys",
                newName: "ProjectCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategory_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategory_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory");

            migrationBuilder.RenameTable(
                name: "ProjectCategory",
                newName: "ProjectCategorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategorys",
                table: "ProjectCategorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategorys_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
