using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "5f11758f-18ac-45d6-96c1-3cecdf157f6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "c7909e87-1ff8-483c-bdb3-8fa0375fe936");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "8249c6e8-1ca6-41dd-9eed-1351c5ef6f6d");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "0f96988e-d2d1-487f-bac3-a02652437950", "AQAAAAEAACcQAAAAEIO3nLnO/s9annYUUiyoejOk7cV5oNELEVtRwgXwad7EyUVlAuNqHmeLN8xxhgxkHg==", new DateTimeOffset(new DateTime(2020, 5, 28, 12, 51, 26, 530, DateTimeKind.Unspecified).AddTicks(1851), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "fcd377d7-a6aa-422c-9758-f5e34dddfa4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "e587f085-f9fa-4663-84ab-2cc83c88f6b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "a179f95b-727f-4e5b-b142-691e404b06fc");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "45d0d4d8-341e-4d84-b51e-e0503a32af2a", "AQAAAAEAACcQAAAAEFTNjuLOI8r3N+7sQ5vcUsNdTq7frml22ygegHdtriT2w8GUaFfmg+Iog4Q/RuOocQ==", new DateTimeOffset(new DateTime(2020, 5, 28, 12, 49, 4, 821, DateTimeKind.Unspecified).AddTicks(1971), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
