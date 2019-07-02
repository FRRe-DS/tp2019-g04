using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class xx2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "LineasRecetas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "LineasRecetas");
        }
    }
}
