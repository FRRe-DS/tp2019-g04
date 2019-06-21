using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class xx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    GrupoSanguineo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VisitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

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
                    RecetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasRecetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasRecetas_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: true),
                    Sintomas = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: false),
                    HistoriaClinicaId = table.Column<int>(nullable: false),
                    PartidaMedicamentoId = table.Column<int>(nullable: false),
                    RecetaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlergiasyEnfermedades_HistoriaClinicaId",
                table: "AlergiasyEnfermedades",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacienteId",
                table: "HistoriasClinicas",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineasRecetas_RecetaId",
                table: "LineasRecetas",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_HistoriaClinicaId",
                table: "Visitas",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_RecetaId",
                table: "Visitas",
                column: "RecetaId",
                unique: true,
                filter: "[RecetaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlergiasyEnfermedades");

            migrationBuilder.DropTable(
                name: "LineasRecetas");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}
