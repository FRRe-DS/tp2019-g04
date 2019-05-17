using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class m008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Enfermedades",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "HistoriasClinicas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alergias",
                table: "HistoriasClinicas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enfermedades",
                table: "HistoriasClinicas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "HistoriasClinicas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "HistoriasClinicas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
