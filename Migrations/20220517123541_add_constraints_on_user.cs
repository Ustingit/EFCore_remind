using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2DBFirst.Migrations
{
    public partial class add_constraints_on_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "Age",
                table: "Users",
                sql: "Age > 0 AND Age < 120");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Age",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: true,
                defaultValueSql: "DATETIME('now')");
        }
    }
}
