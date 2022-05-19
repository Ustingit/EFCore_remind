using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2DBFirst.Migrations
{
    public partial class add_constraints_on_colors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "ColorValue",
                table: "Colours",
                sql: "ColorValue > 0 AND ColorValue < 567675");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ColorValue",
                table: "Colours");
        }
    }
}
