using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingMVC.Migrations
{
    public partial class modeling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "BackedProjects");

            migrationBuilder.AddColumn<string>(
                name: "FundReward",
                table: "Funds",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FundId",
                table: "BackedProjects",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BackedProjectsId",
                table: "BackedProjects",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects",
                column: "BackedProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_BackedProjects_FundId",
                table: "BackedProjects",
                column: "FundId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "FundId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects");

            migrationBuilder.DropIndex(
                name: "IX_BackedProjects_FundId",
                table: "BackedProjects");

            migrationBuilder.DropColumn(
                name: "FundReward",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "BackedProjectsId",
                table: "BackedProjects");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Funds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "FundId",
                table: "BackedProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "BackedProjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackedProjects",
                table: "BackedProjects",
                column: "FundId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackedProjects_Funds_FundId",
                table: "BackedProjects",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "FundId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
