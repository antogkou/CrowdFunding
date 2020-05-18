using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCH.Migrations
{
    public partial class ant1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCategory",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCategoryId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategorys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategorys_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategorys_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectCategoryId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCategory",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
