using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class pourgou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "d9333984-dde8-4894-a3f4-44945dd677e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b013fbe7-9058-4294-a9c1-730e5fc6b369", "Project Creator", "PROJECT CREATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "e03a76e8-5eab-48c3-a4a2-b46b7da0ac81");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "5040133f-20e8-4303-b48f-23ccb183c1dc", "AQAAAAEAACcQAAAAEKP1BqrA8eizO8EvBxLgdz1WqOtMvn0bROMFSzWc36ZzSMgVXjVXQVCfF6reIJAOSw==", new DateTimeOffset(new DateTime(2020, 5, 30, 12, 41, 23, 267, DateTimeKind.Unspecified).AddTicks(8662), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "19b7bc77-336a-4673-815f-a10bb07ff7a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8783aab-839b-4f3b-9e38-075abef22024", "ProjectCreator", "CREATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "1be4a310-069c-4853-94bb-5378d946f791");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "c538b8d3-42b3-49e3-86fe-7d821833e24c", "AQAAAAEAACcQAAAAEABP1J66VqIaCOsmngsmByx4iIWHexDHpDvs4f4GeNfGi1j/pI9g8Um8/D2UIe45xw==", new DateTimeOffset(new DateTime(2020, 5, 30, 0, 44, 33, 650, DateTimeKind.Unspecified).AddTicks(2259), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
