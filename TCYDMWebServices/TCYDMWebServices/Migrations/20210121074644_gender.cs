using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCYDMWebServices.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BornYear",
                table: "Users",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornYear",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");
        }
    }
}
