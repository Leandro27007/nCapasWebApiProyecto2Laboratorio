using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relacionUnoMuchoTurnoYEstadoTurno2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.DropIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.DropColumn(
                name: "EstadoTurnoId",
                table: "turno");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTurnoId",
                table: "turno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId",
                principalTable: "estadoTurno",
                principalColumn: "EstadoTurnoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.DropIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.DropColumn(
                name: "EstadoTurnoId",
                table: "turno");
        }
    }
}
