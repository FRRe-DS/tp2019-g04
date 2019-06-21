using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class xx2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades");

            migrationBuilder.AlterColumn<int>(
                name: "HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades");

            migrationBuilder.AlterColumn<int>(
                name: "HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
