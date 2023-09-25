using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntidadTurnoConRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PruebaDeLaboratorioRecibo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "EstadoTurno",
                columns: table => new
                {
                    EstadoTurnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTurno", x => x.EstadoTurnoId);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    TurnoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoTurnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.TurnoId);
                    table.ForeignKey(
                        name: "FK_Turno_EstadoTurno_EstadoTurnoId",
                        column: x => x.EstadoTurnoId,
                        principalTable: "EstadoTurno",
                        principalColumn: "EstadoTurnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnoPruebaDeLaboratorio",
                columns: table => new
                {
                    TurnoPruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoPruebaDeLaboratorio", x => x.TurnoPruebaDeLaboratorioId);
                    table.ForeignKey(
                        name: "FK_TurnoPruebaDeLaboratorio_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "TurnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnoPruebaDeLaboratorio_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                        column: x => x.PruebaDeLaboratorioId,
                        principalTable: "pruebaDeLaboratorios",
                        principalColumn: "PruebaDeLaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turno_EstadoTurnoId",
                table: "Turno",
                column: "EstadoTurnoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "TurnoPruebaDeLaboratorio",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPruebaDeLaboratorio_TurnoId",
                table: "TurnoPruebaDeLaboratorio",
                column: "TurnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnoPruebaDeLaboratorio");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "EstadoTurno");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Roles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PruebaDeLaboratorioRecibo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
