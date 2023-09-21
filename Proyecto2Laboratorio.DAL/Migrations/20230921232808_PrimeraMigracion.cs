using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "estadoRecibo",
                columns: table => new
                {
                    EstadoReciboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoRecibo", x => x.EstadoReciboId);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "pruebaDeLaboratorios",
                columns: table => new
                {
                    PruebaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pruebaDeLaboratorios", x => x.PruebaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    ReciboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CedulaCliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CedulaMedico = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CedulaUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoReciboId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_Recibo_Cliente_CedulaCliente",
                        column: x => x.CedulaCliente,
                        principalTable: "Cliente",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibo_Medico_CedulaMedico",
                        column: x => x.CedulaMedico,
                        principalTable: "Medico",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibo_Usuario_CedulaUsuario",
                        column: x => x.CedulaUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibo_estadoRecibo_EstadoReciboId",
                        column: x => x.EstadoReciboId,
                        principalTable: "estadoRecibo",
                        principalColumn: "EstadoReciboId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PruebaDeLaboratorioRecibo",
                columns: table => new
                {
                    PruebasDeLaboratorioPruebaId = table.Column<int>(type: "int", nullable: false),
                    RecibosReciboId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruebaDeLaboratorioRecibo", x => new { x.PruebasDeLaboratorioPruebaId, x.RecibosReciboId });
                    table.ForeignKey(
                        name: "FK_PruebaDeLaboratorioRecibo_Recibo_RecibosReciboId",
                        column: x => x.RecibosReciboId,
                        principalTable: "Recibo",
                        principalColumn: "ReciboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebasDeLaboratorioPruebaId",
                        column: x => x.PruebasDeLaboratorioPruebaId,
                        principalTable: "pruebaDeLaboratorios",
                        principalColumn: "PruebaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruebaDeLaboratorioRecibo_RecibosReciboId",
                table: "PruebaDeLaboratorioRecibo",
                column: "RecibosReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_CedulaCliente",
                table: "Recibo",
                column: "CedulaCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_CedulaMedico",
                table: "Recibo",
                column: "CedulaMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_CedulaUsuario",
                table: "Recibo",
                column: "CedulaUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_EstadoReciboId",
                table: "Recibo",
                column: "EstadoReciboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "pruebaDeLaboratorios");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "estadoRecibo");
        }
    }
}
