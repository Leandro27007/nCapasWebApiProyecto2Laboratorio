using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relacionUnoMuchoTurnoYEstadoTurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.CreateIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.CreateIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId",
                unique: true);
        }
    }
}
