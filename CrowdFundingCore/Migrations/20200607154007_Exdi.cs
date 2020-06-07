using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class Exdi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "b2671ce6-3480-473c-8097-72f33beeab7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "5cddfcb7-c914-4104-974c-4357f7a25926");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "bd213a42-085a-4bd8-a784-efdc1ae336f9");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "7923e8cc-2c3c-493a-8164-f914c3c03bf1", "AQAAAAEAACcQAAAAEA/PI4iJXiAe8AvCwwpEu+Og2H5MEQtW6R66ado4k4C5vYhxwPyxd7X/iyG7zn3dPw==", new DateTimeOffset(new DateTime(2020, 6, 7, 18, 40, 7, 390, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "c9ad10e9-1839-4d93-8719-c4a169eb7ffe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "a604e25f-c53b-4e01-a41d-a0e6c0a2aa66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "f987d307-4f33-4591-a080-299f03ecb0f4");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "e92879ca-cc7f-4a64-a8c7-dad4943323ce", "AQAAAAEAACcQAAAAEONL00RHi4lNZSfkWNOqgDy+rh5DF/ZfCrXh3AihC9uwZBasW2RZg0lp9zIPem+yMg==", new DateTimeOffset(new DateTime(2020, 6, 6, 6, 6, 14, 653, DateTimeKind.Unspecified).AddTicks(3515), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
