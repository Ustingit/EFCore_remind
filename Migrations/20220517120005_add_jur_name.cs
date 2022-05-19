using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2DBFirst.Migrations
{
    public partial class add_jur_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "juriName",
                table: "Company",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "juriName",
                table: "Company");
        }
    }
}
