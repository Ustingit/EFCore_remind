using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore2DBFirst.Migrations
{
    public partial class try_to_add_countries_table4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.CreateTable(
		        name: "Countries",
		        columns: table => new
		        {
			        Id = table.Column<int>(type: "INTEGER", nullable: false)
				        .Annotation("Sqlite:Autoincrement", true),
			        Name = table.Column<int>(type: "TEXT", nullable: false)
		        },
		        constraints: table =>
		        {
			        table.PrimaryKey("PK_Countries", x => x.Id);
		        });

            migrationBuilder.AlterColumn<string>(
		        name: "Name",
		        table: "Countries",
		        type: "TEXT",
		        nullable: false,
		        defaultValue: "",
		        oldClrType: typeof(string),
		        oldType: "TEXT",
		        oldNullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.AlterColumn<string>(
		        name: "Name",
		        table: "Countries",
		        type: "TEXT",
		        nullable: true,
		        oldClrType: typeof(string),
		        oldType: "TEXT");

            migrationBuilder.DropTable(
		        name: "Countries");
        }
    }
}
