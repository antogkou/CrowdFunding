using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_VAT",
                table: "MyUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "125a91fc-4944-458c-87fc-2e2939df3cbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "7da98c53-bb06-44e6-959e-eeaeaebb94de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "06a5566a-490c-4e5a-b526-52fbb472f50d");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "9dd96fda-5983-44dc-938f-d812a5faa2f3", "AQAAAAEAACcQAAAAECkLDbXg+mp4JREbdHlSxtnfmcm/QzVRjpPHyeQLEUkDvKcLJCUbZSaZOMFllEkbWw==", new DateTimeOffset(new DateTime(2020, 6, 4, 14, 22, 6, 652, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_VAT",
                table: "MyUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "d0a2347d-8e14-4c81-bb4f-6612e170c060");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "17b33d8e-340d-40c5-829b-4019237e89be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "f1658f70-a0b7-40c0-b3f2-1c764b900d3a");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "5467695a-b7ee-48bb-9f2b-14c7bf8f0c17", "AQAAAAEAACcQAAAAECfXkMwnJSuZJflkv/lZ/NKqi+98Xkq2YviouwenINyJ8JmGm8VyeWcEpsqOUE6uAA==", new DateTimeOffset(new DateTime(2020, 6, 4, 2, 15, 7, 198, DateTimeKind.Unspecified).AddTicks(3890), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
