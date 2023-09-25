using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaIntermediaConFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_Recibo_RecibosReciboId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebasDeLaboratorioPruebaId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.RenameColumn(
                name: "PruebaId",
                table: "pruebaDeLaboratorios",
                newName: "PruebaDeLaboratorioId");

            migrationBuilder.RenameColumn(
                name: "RecibosReciboId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "ReciboId");

            migrationBuilder.RenameColumn(
                name: "PruebasDeLaboratorioPruebaId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "PruebaDeLaboratorioId");

            migrationBuilder.RenameIndex(
                name: "IX_PruebaDeLaboratorioRecibo_RecibosReciboId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "IX_PruebaDeLaboratorioRecibo_ReciboId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PruebaDeLaboratorioRecibo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "PruebaDeLaboratorioRecibo",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PruebaDeLaboratorioRecibo_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_Recibo_ReciboId",
                table: "PruebaDeLaboratorioRecibo",
                column: "ReciboId",
                principalTable: "Recibo",
                principalColumn: "ReciboId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo",
                column: "PruebaDeLaboratorioId",
                principalTable: "pruebaDeLaboratorios",
                principalColumn: "PruebaDeLaboratorioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_Recibo_ReciboId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropIndex(
                name: "IX_PruebaDeLaboratorioRecibo_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.RenameColumn(
                name: "PruebaDeLaboratorioId",
                table: "pruebaDeLaboratorios",
                newName: "PruebaId");

            migrationBuilder.RenameColumn(
                name: "ReciboId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "RecibosReciboId");

            migrationBuilder.RenameColumn(
                name: "PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "PruebasDeLaboratorioPruebaId");

            migrationBuilder.RenameIndex(
                name: "IX_PruebaDeLaboratorioRecibo_ReciboId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "IX_PruebaDeLaboratorioRecibo_RecibosReciboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo",
                columns: new[] { "PruebasDeLaboratorioPruebaId", "RecibosReciboId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_Recibo_RecibosReciboId",
                table: "PruebaDeLaboratorioRecibo",
                column: "RecibosReciboId",
                principalTable: "Recibo",
                principalColumn: "ReciboId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebasDeLaboratorioPruebaId",
                table: "PruebaDeLaboratorioRecibo",
                column: "PruebasDeLaboratorioPruebaId",
                principalTable: "pruebaDeLaboratorios",
                principalColumn: "PruebaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
