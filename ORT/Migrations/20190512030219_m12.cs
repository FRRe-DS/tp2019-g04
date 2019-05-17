using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Visitas",
                newName: "Diagnostico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diagnostico",
                table: "Visitas",
                newName: "Descripcion");
        }
    }
}
