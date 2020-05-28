using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    LastChangedDateTime = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    InternalIdentifier = table.Column<string>(nullable: true),
                    LandingPageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    LastChangedDateTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    LastChangedDateTime = table.Column<DateTime>(nullable: false),
                    LoggedInDateTime = table.Column<DateTime>(nullable: false),
                    LoggedOutDateTime = table.Column<DateTime>(nullable: true),
                    LoggedInUserId = table.Column<int>(nullable: false),
                    ClientIp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_Users_LoggedInUserId",
                        column: x => x.LoggedInUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDateTime", "DisplayName", "InternalIdentifier", "LandingPageUrl", "LastChangedDateTime" },
                values: new object[] { 1, new DateTime(2020, 5, 29, 0, 45, 54, 372, DateTimeKind.Local).AddTicks(4503), "Auditor", "INTERNAL_AUDITOR", "/audit", new DateTime(2020, 5, 29, 0, 45, 54, 373, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDateTime", "DisplayName", "InternalIdentifier", "LandingPageUrl", "LastChangedDateTime" },
                values: new object[] { 2, new DateTime(2020, 5, 29, 0, 45, 54, 373, DateTimeKind.Local).AddTicks(1495), "User", "USER", "/", new DateTime(2020, 5, 29, 0, 45, 54, 373, DateTimeKind.Local).AddTicks(1499) });

            migrationBuilder.CreateIndex(
                name: "IX_Audits_LoggedInUserId",
                table: "Audits",
                column: "LoggedInUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
