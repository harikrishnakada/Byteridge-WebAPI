using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LoggedOutDateTime",
                table: "Audits",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "LastChangedDateTime" },
                values: new object[] { new DateTime(2020, 5, 25, 10, 49, 50, 805, DateTimeKind.Local).AddTicks(1190), new DateTime(2020, 5, 25, 10, 49, 50, 805, DateTimeKind.Local).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "LastChangedDateTime" },
                values: new object[] { new DateTime(2020, 5, 25, 10, 49, 50, 805, DateTimeKind.Local).AddTicks(7905), new DateTime(2020, 5, 25, 10, 49, 50, 805, DateTimeKind.Local).AddTicks(7909) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LoggedOutDateTime",
                table: "Audits",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "LastChangedDateTime" },
                values: new object[] { new DateTime(2020, 5, 25, 0, 1, 20, 607, DateTimeKind.Local).AddTicks(8965), new DateTime(2020, 5, 25, 0, 1, 20, 608, DateTimeKind.Local).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "LastChangedDateTime" },
                values: new object[] { new DateTime(2020, 5, 25, 0, 1, 20, 608, DateTimeKind.Local).AddTicks(9155), new DateTime(2020, 5, 25, 0, 1, 20, 608, DateTimeKind.Local).AddTicks(9161) });
        }
    }
}
