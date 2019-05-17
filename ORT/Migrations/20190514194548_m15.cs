using Microsoft.EntityFrameworkCore.Migrations;

namespace ORT.Migrations
{
    public partial class m15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasRecetas_Recetas_RecetaId1",
                table: "LineasRecetas");

            migrationBuilder.DropIndex(
                name: "IX_LineasRecetas_RecetaId1",
                table: "LineasRecetas");

            migrationBuilder.DropColumn(
                name: "LineaRecetaId",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "RecetaId1",
                table: "LineasRecetas");

            migrationBuilder.CreateIndex(
                name: "IX_LineasRecetas_RecetaId",
                table: "LineasRecetas",
                column: "RecetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasRecetas_Recetas_RecetaId",
                table: "LineasRecetas",
                column: "RecetaId",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasRecetas_Recetas_RecetaId",
                table: "LineasRecetas");

            migrationBuilder.DropIndex(
                name: "IX_LineasRecetas_RecetaId",
                table: "LineasRecetas");

            migrationBuilder.AddColumn<int>(
                name: "LineaRecetaId",
                table: "Recetas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecetaId1",
                table: "LineasRecetas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineasRecetas_RecetaId1",
                table: "LineasRecetas",
                column: "RecetaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasRecetas_Recetas_RecetaId1",
                table: "LineasRecetas",
                column: "RecetaId1",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
