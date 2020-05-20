using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingMVC.Migrations
{
    public partial class modeling1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects");

            migrationBuilder.DropColumn(
                name: "BackedProjectId",
                table: "BackedProjects");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FundDateCreated",
                table: "Funds",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Funds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FundId",
                table: "BackedProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "BackedFundDateCreated",
                table: "BackedProjects",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_Funds_ProjectId",
                table: "Funds",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "FundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_Projects_ProjectId",
                table: "Funds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Funds_Projects_ProjectId",
                table: "Funds");

            migrationBuilder.DropIndex(
                name: "IX_Funds_ProjectId",
                table: "Funds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects");

            migrationBuilder.DropColumn(
                name: "FundDateCreated",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "FundId",
                table: "BackedProjects");

            migrationBuilder.DropColumn(
                name: "BackedFundDateCreated",
                table: "BackedProjects");

            migrationBuilder.AddColumn<int>(
                name: "BackedProjectId",
                table: "BackedProjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects",
                column: "BackedProjectId");
        }
    }
}
