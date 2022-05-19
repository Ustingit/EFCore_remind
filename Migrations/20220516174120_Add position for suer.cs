using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2DBFirst.Migrations
{
    public partial class Addpositionforsuer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
	            name: "Position", 
	            table: "Users",
	            type: "TEXT",
	            nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Users");
        }
    }
}
