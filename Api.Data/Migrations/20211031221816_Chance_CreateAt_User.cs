using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Chance_CreateAt_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "MyProperty",
                table: "User",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
