using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EliminoEntidadEstadoTurnoMeEstabaDandoProblemasConRelacionAhoraElEstadoTurnoEstaLiteralEnLaEntidadTurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno");


            migrationBuilder.DropTable(
                name: "estadoTurno");

            migrationBuilder.DropIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno");


            migrationBuilder.DropColumn(
                name: "EstadoTurnoId",
                table: "turno");


            migrationBuilder.AddColumn<string>(
                name: "EstadoTurno",
                table: "turno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoTurno",
                table: "turno");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTurnoId",
                table: "turno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoTurnoId1",
                table: "turno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "estadoTurno",
                columns: table => new
                {
                    EstadoTurnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoTurno", x => x.EstadoTurnoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_turno_EstadoTurnoId1",
                table: "turno",
                column: "EstadoTurnoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId",
                principalTable: "estadoTurno",
                principalColumn: "EstadoTurnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId1",
                table: "turno",
                column: "EstadoTurnoId1",
                principalTable: "estadoTurno",
                principalColumn: "EstadoTurnoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
