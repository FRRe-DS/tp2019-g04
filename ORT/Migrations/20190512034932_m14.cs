using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class m14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartidaMedicamentoId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "CantidadDeMedicamentosRecetados",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Enfermedades",
                table: "HistoriasClinicas");

            migrationBuilder.RenameColumn(
                name: "Medicamentos",
                table: "Recetas",
                newName: "LineaRecetaId");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaClinicaId",
                table: "Visitas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PartidaMedicamentoRealizado",
                table: "Visitas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "HistoriasClinicas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AlergiasyEnfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    HistoriaClinicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlergiasyEnfermedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlergiasyEnfermedades_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineasRecetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicamentoId = table.Column<int>(nullable: false),
                    CantidadRecetado = table.Column<int>(nullable: false),
                    RecetaId = table.Column<int>(nullable: false),
                    RecetaId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasRecetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasRecetas_Recetas_RecetaId1",
                        column: x => x.RecetaId1,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_HistoriaClinicaId",
                table: "Visitas",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlergiasyEnfermedades_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasRecetas_RecetaId1",
                table: "LineasRecetas",
                column: "RecetaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_HistoriasClinicas_HistoriaClinicaId",
                table: "Visitas",
                column: "HistoriaClinicaId",
                principalTable: "HistoriasClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_HistoriasClinicas_HistoriaClinicaId",
                table: "Visitas");

            migrationBuilder.DropTable(
                name: "AlergiasyEnfermedades");

            migrationBuilder.DropTable(
                name: "LineasRecetas");

            migrationBuilder.DropIndex(
                name: "IX_Visitas_HistoriaClinicaId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "HistoriaClinicaId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "PartidaMedicamentoRealizado",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "HistoriasClinicas");

            migrationBuilder.RenameColumn(
                name: "LineaRecetaId",
                table: "Recetas",
                newName: "Medicamentos");

            migrationBuilder.AddColumn<int>(
                name: "PartidaMedicamentoId",
                table: "Visitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadDeMedicamentosRecetados",
                table: "Recetas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Alergias",
                table: "HistoriasClinicas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enfermedades",
                table: "HistoriasClinicas",
                nullable: true);
        }
    }
}
