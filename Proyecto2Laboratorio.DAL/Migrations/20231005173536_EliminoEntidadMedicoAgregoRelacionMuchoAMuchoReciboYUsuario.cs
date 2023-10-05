using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EliminoEntidadMedicoAgregoRelacionMuchoAMuchoReciboYUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_cliente_CedulaCliente",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_medico_CedulaMedico",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_CedulaUsuario",
                table: "recibo");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropIndex(
                name: "IX_recibo_CedulaCliente",
                table: "recibo");

            migrationBuilder.DropIndex(
                name: "IX_recibo_CedulaMedico",
                table: "recibo");

            migrationBuilder.DropIndex(
                name: "IX_recibo_CedulaUsuario",
                table: "recibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "CedulaCliente",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "CedulaMedico",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "CedulaUsuario",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "recibo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "cliente",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "ClienteId");

            migrationBuilder.CreateTable(
                name: "usuarioRecibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciboId1 = table.Column<int>(type: "int", nullable: false),
                    ReciboId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioRecibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarioRecibo_recibo_ReciboId1",
                        column: x => x.ReciboId1,
                        principalTable: "recibo",
                        principalColumn: "ReciboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarioRecibo_usuario_UsuarioCedula",
                        column: x => x.UsuarioCedula,
                        principalTable: "usuario",
                        principalColumn: "Cedula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_recibo_ClienteId",
                table: "recibo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRecibo_ReciboId1",
                table: "usuarioRecibo",
                column: "ReciboId1");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRecibo_UsuarioCedula",
                table: "usuarioRecibo",
                column: "UsuarioCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_cliente_ClienteId",
                table: "recibo",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_cliente_ClienteId",
                table: "recibo");

            migrationBuilder.DropTable(
                name: "usuarioRecibo");

            migrationBuilder.DropIndex(
                name: "IX_recibo_ClienteId",
                table: "recibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "cliente");

            migrationBuilder.AddColumn<string>(
                name: "CedulaCliente",
                table: "recibo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CedulaMedico",
                table: "recibo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CedulaUsuario",
                table: "recibo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "cliente",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Cedula");

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.Cedula);
                });

            migrationBuilder.CreateIndex(
                name: "IX_recibo_CedulaCliente",
                table: "recibo",
                column: "CedulaCliente");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_CedulaMedico",
                table: "recibo",
                column: "CedulaMedico");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_CedulaUsuario",
                table: "recibo",
                column: "CedulaUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_cliente_CedulaCliente",
                table: "recibo",
                column: "CedulaCliente",
                principalTable: "cliente",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_medico_CedulaMedico",
                table: "recibo",
                column: "CedulaMedico",
                principalTable: "medico",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_CedulaUsuario",
                table: "recibo",
                column: "CedulaUsuario",
                principalTable: "usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
