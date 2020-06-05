using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class gegeg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MultimediaURL",
                table: "Multimedia",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "80171e67-414c-45a2-bfd9-d0f79662c392");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "39cfdcea-af7e-448b-a18e-a2459f495119");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "a00475c8-01b7-4c3a-ab61-fbeae037ca48");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "22ee2ed5-9d98-4d23-9a3d-66afdd91c5f5", "AQAAAAEAACcQAAAAEJhDm2dkRTbwEPZm7eVtuBQHWIYlkASzBivJcqADbqHdZ2Y5E/bR3V3rumktkCwglg==", new DateTimeOffset(new DateTime(2020, 6, 6, 1, 27, 55, 800, DateTimeKind.Unspecified).AddTicks(8867), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MultimediaURL",
                table: "Multimedia",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "6f8f941f-80bb-4245-bb25-6817841fda5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "b994094e-7f79-418a-88c7-8a7a773c7a48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "9b2ed52f-3a97-45fa-bc3f-c53801a99339");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "ebcfdda5-3e05-44e5-9993-a0390798e636", "AQAAAAEAACcQAAAAECPOQpHVEKz6MKKc+IBZ/ghpvobdnIzCeWCvU9PFha03KEe91wpi9xpz+qeGkeY/7Q==", new DateTimeOffset(new DateTime(2020, 6, 6, 1, 9, 32, 778, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
