using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class CustomUserData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userFirstName",
                table: "MyUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userLastName",
                table: "MyUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "e55c2253-1a0e-4dfa-b65f-9dcde870350b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "0bb47f59-0d6b-4e3f-ace9-d291da9921bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "4e10c4e2-1883-4b8a-83b0-7e95f51d2744");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "02f0f35a-d085-4487-a744-9ad864ec0258", "AQAAAAEAACcQAAAAEDRdHQswrVsMq8ywDZ/DttnAvLS/G8HwBVqJSYI+myzLYUipcE0kBf2CLPtEjWRR/Q==", new DateTimeOffset(new DateTime(2020, 6, 4, 14, 38, 27, 830, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userFirstName",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "userLastName",
                table: "MyUsers");

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
    }
}
