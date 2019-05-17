using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class m003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriasClinicas_Pacientes_PacienteId",
                table: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_HistoriasClinicas_PacienteId",
                table: "HistoriasClinicas");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Visitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidaMedicamentoId",
                table: "Visitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecetaId",
                table: "Visitas",
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

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "HistoriasClinicas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadDeMedicamentosRecetados = table.Column<int>(nullable: false),
                    Medicamentos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_RecetaId",
                table: "Visitas",
                column: "RecetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Recetas_RecetaId",
                table: "Visitas",
                column: "RecetaId",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Recetas_RecetaId",
                table: "Visitas");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropIndex(
                name: "IX_Visitas_RecetaId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "PartidaMedicamentoId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "RecetaId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "Alergias",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Enfermedades",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "HistoriasClinicas");

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HistoriaClinicaId = table.Column<int>(nullable: true),
                    VisitaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Visitas_VisitaId",
                        column: x => x.VisitaId,
                        principalTable: "Visitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacienteId",
                table: "HistoriasClinicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_HistoriaClinicaId",
                table: "Medicamentos",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_VisitaId",
                table: "Medicamentos",
                column: "VisitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriasClinicas_Pacientes_PacienteId",
                table: "HistoriasClinicas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
