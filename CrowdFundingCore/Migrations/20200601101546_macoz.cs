using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundingCore.Migrations
{
    public partial class macoz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProjectTitle = table.Column<string>(maxLength: 255, nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectTargetAmount = table.Column<decimal>(maxLength: 20, nullable: false),
                    ProjectCurrentAmount = table.Column<decimal>(nullable: false),
                    ProjectProgress = table.Column<decimal>(nullable: false),
                    ProjectViews = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    ProjectCreationDate = table.Column<DateTimeOffset>(nullable: false),
                    ProjectEndingDate = table.Column<DateTime>(nullable: false),
                    ProjectCategory = table.Column<string>(nullable: true),
                    ProjectCreator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    MultimediaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    ProjectPhotoProfile = table.Column<string>(nullable: true),
                    MultimediaURL = table.Column<string>(maxLength: 255, nullable: false),
                    MultimediaTypes = table.Column<int>(nullable: false),
                    MultimediaDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.MultimediaId);
                    table.ForeignKey(
                        name: "FK_Multimedia_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pledge",
                columns: table => new
                {
                    PledgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    PledgeTitle = table.Column<string>(maxLength: 255, nullable: false),
                    PledgeDescription = table.Column<string>(nullable: true),
                    PledgePrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    PledgeReward = table.Column<string>(nullable: true),
                    PledgeDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pledge", x => x.PledgeId);
                    table.ForeignKey(
                        name: "FK_Pledge_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    PostTitle = table.Column<string>(maxLength: 255, nullable: false),
                    PostDescription = table.Column<string>(nullable: true),
                    PostDateCreated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackedPledges",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PledgeId = table.Column<int>(nullable: false),
                    created_BackedPledge = table.Column<DateTimeOffset>(nullable: false),
                    BackedPledgesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackedPledges", x => new { x.UserId, x.PledgeId, x.created_BackedPledge });
                    table.ForeignKey(
                        name: "FK_BackedPledges_Pledge_PledgeId",
                        column: x => x.PledgeId,
                        principalTable: "Pledge",
                        principalColumn: "PledgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackedPledges_MyUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "63dd3107-ace7-4ac9-99ed-dac9fb2a20b5", "Administrator", "ADMINISTRATOR" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "abf72595-bea1-4ff0-acc6-7f8f861e6e70", "Backer", "BACKER" },
                    { "78A7570F-3CE5-48BA-9461-80283ED1D94D", "06dfd056-a20f-467a-9d42-7ad767000fc4", "Project Creator", "PROJECT CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserDateCreated", "UserName" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, "273039dc-3629-446a-be94-5f46dd24583e", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJc3wW5JKKG6pOk/B/glMrFwwTZg4dTt1BvnS3Y7ItNJygwyvjDvuuZMHuWmD61cpA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, new DateTimeOffset(new DateTime(2020, 6, 1, 13, 15, 46, 478, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 3, 0, 0, 0)), "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", "2301D884-221A-4E7D-B509-0113DCC043E1" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BackedPledges_PledgeId",
                table: "BackedPledges",
                column: "PledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_ProjectId",
                table: "Multimedia",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "MyUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "MyUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pledge_ProjectId",
                table: "Pledge",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ProjectId",
                table: "Post",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BackedPledges");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pledge");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "MyUsers");
        }
    }
}
