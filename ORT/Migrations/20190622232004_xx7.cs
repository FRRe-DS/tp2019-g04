using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class xx7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades");

            migrationBuilder.DropIndex(
                name: "IX_AlergiasyEnfermedades_HistoriaClinicaId",
                table: "AlergiasyEnfermedades");

            migrationBuilder.DropColumn(
                name: "HistoriaClinicaId",
                table: "AlergiasyEnfermedades");

            migrationBuilder.CreateTable(
                name: "AyEdeHistoriasClinicas",
                columns: table => new
                {
                    HistoriaClinicaId = table.Column<int>(nullable: false),
                    AlergiayEnfermedadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AyEdeHistoriasClinicas", x => new { x.HistoriaClinicaId, x.AlergiayEnfermedadId });
                    table.ForeignKey(
                        name: "FK_AyEdeHistoriasClinicas_AlergiasyEnfermedades_AlergiayEnfermedadId",
                        column: x => x.AlergiayEnfermedadId,
                        principalTable: "AlergiasyEnfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AyEdeHistoriasClinicas_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AyEdeHistoriasClinicas_AlergiayEnfermedadId",
                table: "AyEdeHistoriasClinicas",
                column: "AlergiayEnfermedadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AyEdeHistoriasClinicas");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlergiasyEnfermedades_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
