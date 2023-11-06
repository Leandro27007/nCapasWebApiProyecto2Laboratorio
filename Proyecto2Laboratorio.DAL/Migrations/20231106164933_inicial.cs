using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "pruebaDeLaboratorio",
                columns: table => new
                {
                    PruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pruebaDeLaboratorio", x => x.PruebaDeLaboratorioId);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    TurnoId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoTurno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turno", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turnoPruebaDeLaboratorio",
                columns: table => new
                {
                    TurnoPruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnoPruebaDeLaboratorio", x => x.TurnoPruebaDeLaboratorioId);
                    table.ForeignKey(
                        name: "FK_turnoPruebaDeLaboratorio_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                        column: x => x.PruebaDeLaboratorioId,
                        principalTable: "pruebaDeLaboratorio",
                        principalColumn: "PruebaDeLaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turnoPruebaDeLaboratorio_turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "turno",
                        principalColumn: "TurnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recibo",
                columns: table => new
                {
                    ReciboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCF = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdUltimoUsuarioQueModifico = table.Column<int>(type: "int", nullable: true),
                    NotaDeModificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recibo", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_recibo_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recibo_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pruebaDeLaboratorioRecibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PruebaDeLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    ReciboId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pruebaDeLaboratorioRecibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pruebaDeLaboratorioRecibo_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                        column: x => x.PruebaDeLaboratorioId,
                        principalTable: "pruebaDeLaboratorio",
                        principalColumn: "PruebaDeLaboratorioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pruebaDeLaboratorioRecibo_recibo_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "recibo",
                        principalColumn: "ReciboId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pruebaDeLaboratorioRecibo_PruebaDeLaboratorioId",
                table: "pruebaDeLaboratorioRecibo",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_pruebaDeLaboratorioRecibo_ReciboId",
                table: "pruebaDeLaboratorioRecibo",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_ClienteId",
                table: "recibo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_UsuarioId",
                table: "recibo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_turnoPruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "turnoPruebaDeLaboratorio",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_turnoPruebaDeLaboratorio_TurnoId",
                table: "turnoPruebaDeLaboratorio",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_RolId",
                table: "usuario",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pruebaDeLaboratorioRecibo");

            migrationBuilder.DropTable(
                name: "turnoPruebaDeLaboratorio");

            migrationBuilder.DropTable(
                name: "recibo");

            migrationBuilder.DropTable(
                name: "pruebaDeLaboratorio");

            migrationBuilder.DropTable(
                name: "turno");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
