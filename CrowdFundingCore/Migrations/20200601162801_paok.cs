using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class paok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "fa532168-0147-41f8-a9ae-5f1d7e9bb8d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "bca52847-2e86-4409-8208-5c19439807b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "c2f7359f-0dcd-4040-980c-a9212b10ac13");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "263d49d3-f673-41d8-b1d9-e8996db91fec", "AQAAAAEAACcQAAAAEO8gdYHBQrhLN83CVbMZOOwpE5VcusSZHUrJfS4ZuVunh77f0ySFS6agKhzjpYeEzg==", new DateTimeOffset(new DateTime(2020, 6, 1, 19, 28, 1, 571, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "f4e068aa-8a4a-4fd1-9734-f39bf1dcd29f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "374acca2-54b6-462f-ae91-a3460f37be4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "26b81901-de15-4249-948f-07d5a497abfa");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "0edd9395-064a-4c95-92be-c6bcbfc66044", "AQAAAAEAACcQAAAAEOCtjQVfNxUk4E/7hSEXqqJeTpcrq/bQAaGolYSNDl09w8l7mOZXirnLyp0Xm7YR2g==", new DateTimeOffset(new DateTime(2020, 6, 1, 14, 24, 57, 724, DateTimeKind.Unspecified).AddTicks(9257), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
