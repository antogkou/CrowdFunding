using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "73596283-1c10-4cc6-9dd8-1b7767f623a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "543ee96e-483e-4cd5-8bc1-d8803a3a0a71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "a31e973e-df4b-44bc-a03c-ef6c3cbacee5");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "e37e86c3-ab24-4c2c-bcd6-7c4f1afa5f9e", "AQAAAAEAACcQAAAAEHPcCtVXIsLElQjp9MBQBq0yRLKYe2/f8s+3TukwdJQJmQX4rKw/68uUr+LXbcBvNA==", new DateTimeOffset(new DateTime(2020, 6, 6, 12, 54, 24, 736, DateTimeKind.Unspecified).AddTicks(7895), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "531c03c9-cdb3-48e1-a4c8-d7f2a02ce74d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "236b87f3-0471-4f34-b676-ec2c63d24332");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "a0e000fa-39aa-4cae-85b4-b3553ffe06c1");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "0018c13b-aae8-4566-ad43-03e788422cda", "AQAAAAEAACcQAAAAEDlwupoLtm5FB8WgXl4FXFhw8dp4Pcfg2/HOENjyI64Js+DrcNGsdymla6nnnm8aCQ==", new DateTimeOffset(new DateTime(2020, 6, 6, 9, 56, 45, 965, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
