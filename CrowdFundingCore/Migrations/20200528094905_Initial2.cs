using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "96ea2d3f-d25d-4f8e-8444-f369895fbfac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "eaf37114-1593-4b91-8c31-b7cdb9a62dd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "c7278bd4-cd57-4b8d-8876-b91e0d117fe6");

            migrationBuilder.UpdateData(
                table: "MyUsers",
                keyColumn: "UserId",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserDateCreated" },
                values: new object[] { "d448bedd-a665-4237-a232-540c9a0f7efc", "AQAAAAEAACcQAAAAEPRc3Wud3aOFz3AockcLguNknGUWyW5LwQVjicuyTAMqIh9VysZEFc0sAlraKE5h8w==", new DateTimeOffset(new DateTime(2020, 5, 28, 12, 47, 19, 218, DateTimeKind.Unspecified).AddTicks(1079), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
