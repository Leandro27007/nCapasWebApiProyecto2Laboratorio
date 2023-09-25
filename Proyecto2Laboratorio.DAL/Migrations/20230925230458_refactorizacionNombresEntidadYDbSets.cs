using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class refactorizacionNombresEntidadYDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_Recibo_ReciboId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_PruebaDeLaboratorioRecibo_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibo_Cliente_CedulaCliente",
                table: "Recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibo_Medico_CedulaMedico",
                table: "Recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibo_Usuario_CedulaUsuario",
                table: "Recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibo_estadoRecibo_EstadoReciboId",
                table: "Recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_EstadoTurno_EstadoTurnoId",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_TurnoPruebaDeLaboratorio_Turno_TurnoId",
                table: "TurnoPruebaDeLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_TurnoPruebaDeLaboratorio_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                table: "TurnoPruebaDeLaboratorio");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TurnoPruebaDeLaboratorio",
                table: "TurnoPruebaDeLaboratorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turno",
                table: "Turno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recibo",
                table: "Recibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medico",
                table: "Medico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoTurno",
                table: "EstadoTurno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pruebaDeLaboratorios",
                table: "pruebaDeLaboratorios");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "TurnoPruebaDeLaboratorio",
                newName: "turnoPruebaDeLaboratorio");

            migrationBuilder.RenameTable(
                name: "Turno",
                newName: "turno");

            migrationBuilder.RenameTable(
                name: "Recibo",
                newName: "recibo");

            migrationBuilder.RenameTable(
                name: "PruebaDeLaboratorioRecibo",
                newName: "pruebaDeLaboratorioRecibo");

            migrationBuilder.RenameTable(
                name: "Medico",
                newName: "medico");

            migrationBuilder.RenameTable(
                name: "EstadoTurno",
                newName: "estadoTurno");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "cliente");

            migrationBuilder.RenameTable(
                name: "pruebaDeLaboratorios",
                newName: "pruebaDeLaboratorio");

            migrationBuilder.RenameIndex(
                name: "IX_TurnoPruebaDeLaboratorio_TurnoId",
                table: "turnoPruebaDeLaboratorio",
                newName: "IX_turnoPruebaDeLaboratorio_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_TurnoPruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "turnoPruebaDeLaboratorio",
                newName: "IX_turnoPruebaDeLaboratorio_PruebaDeLaboratorioId");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_EstadoTurnoId",
                table: "turno",
                newName: "IX_turno_EstadoTurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_Recibo_EstadoReciboId",
                table: "recibo",
                newName: "IX_recibo_EstadoReciboId");

            migrationBuilder.RenameIndex(
                name: "IX_Recibo_CedulaUsuario",
                table: "recibo",
                newName: "IX_recibo_CedulaUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Recibo_CedulaMedico",
                table: "recibo",
                newName: "IX_recibo_CedulaMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Recibo_CedulaCliente",
                table: "recibo",
                newName: "IX_recibo_CedulaCliente");

            migrationBuilder.RenameIndex(
                name: "IX_PruebaDeLaboratorioRecibo_ReciboId",
                table: "pruebaDeLaboratorioRecibo",
                newName: "IX_pruebaDeLaboratorioRecibo_ReciboId");

            migrationBuilder.RenameIndex(
                name: "IX_PruebaDeLaboratorioRecibo_PruebaDeLaboratorioId",
                table: "pruebaDeLaboratorioRecibo",
                newName: "IX_pruebaDeLaboratorioRecibo_PruebaDeLaboratorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_turnoPruebaDeLaboratorio",
                table: "turnoPruebaDeLaboratorio",
                column: "TurnoPruebaDeLaboratorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_turno",
                table: "turno",
                column: "TurnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recibo",
                table: "recibo",
                column: "ReciboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pruebaDeLaboratorioRecibo",
                table: "pruebaDeLaboratorioRecibo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medico",
                table: "medico",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estadoTurno",
                table: "estadoTurno",
                column: "EstadoTurnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pruebaDeLaboratorio",
                table: "pruebaDeLaboratorio",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.CreateTable(
                name: "permiso",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permiso", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.RolId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_pruebaDeLaboratorioRecibo_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "pruebaDeLaboratorioRecibo",
                column: "PruebaDeLaboratorioId",
                principalTable: "pruebaDeLaboratorio",
                principalColumn: "PruebaDeLaboratorioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pruebaDeLaboratorioRecibo_recibo_ReciboId",
                table: "pruebaDeLaboratorioRecibo",
                column: "ReciboId",
                principalTable: "recibo",
                principalColumn: "ReciboId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_cliente_CedulaCliente",
                table: "recibo",
                column: "CedulaCliente",
                principalTable: "cliente",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_estadoRecibo_EstadoReciboId",
                table: "recibo",
                column: "EstadoReciboId",
                principalTable: "estadoRecibo",
                principalColumn: "EstadoReciboId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno",
                column: "EstadoTurnoId",
                principalTable: "estadoTurno",
                principalColumn: "EstadoTurnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_turnoPruebaDeLaboratorio_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "turnoPruebaDeLaboratorio",
                column: "PruebaDeLaboratorioId",
                principalTable: "pruebaDeLaboratorio",
                principalColumn: "PruebaDeLaboratorioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_turnoPruebaDeLaboratorio_turno_TurnoId",
                table: "turnoPruebaDeLaboratorio",
                column: "TurnoId",
                principalTable: "turno",
                principalColumn: "TurnoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pruebaDeLaboratorioRecibo_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "pruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_pruebaDeLaboratorioRecibo_recibo_ReciboId",
                table: "pruebaDeLaboratorioRecibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_cliente_CedulaCliente",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_estadoRecibo_EstadoReciboId",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_medico_CedulaMedico",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_CedulaUsuario",
                table: "recibo");

            migrationBuilder.DropForeignKey(
                name: "FK_turno_estadoTurno_EstadoTurnoId",
                table: "turno");

            migrationBuilder.DropForeignKey(
                name: "FK_turnoPruebaDeLaboratorio_pruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "turnoPruebaDeLaboratorio");

            migrationBuilder.DropForeignKey(
                name: "FK_turnoPruebaDeLaboratorio_turno_TurnoId",
                table: "turnoPruebaDeLaboratorio");

            migrationBuilder.DropTable(
                name: "permiso");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_turnoPruebaDeLaboratorio",
                table: "turnoPruebaDeLaboratorio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_turno",
                table: "turno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recibo",
                table: "recibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pruebaDeLaboratorioRecibo",
                table: "pruebaDeLaboratorioRecibo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medico",
                table: "medico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estadoTurno",
                table: "estadoTurno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pruebaDeLaboratorio",
                table: "pruebaDeLaboratorio");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "turnoPruebaDeLaboratorio",
                newName: "TurnoPruebaDeLaboratorio");

            migrationBuilder.RenameTable(
                name: "turno",
                newName: "Turno");

            migrationBuilder.RenameTable(
                name: "recibo",
                newName: "Recibo");

            migrationBuilder.RenameTable(
                name: "pruebaDeLaboratorioRecibo",
                newName: "PruebaDeLaboratorioRecibo");

            migrationBuilder.RenameTable(
                name: "medico",
                newName: "Medico");

            migrationBuilder.RenameTable(
                name: "estadoTurno",
                newName: "EstadoTurno");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "Cliente");

            migrationBuilder.RenameTable(
                name: "pruebaDeLaboratorio",
                newName: "pruebaDeLaboratorios");

            migrationBuilder.RenameIndex(
                name: "IX_turnoPruebaDeLaboratorio_TurnoId",
                table: "TurnoPruebaDeLaboratorio",
                newName: "IX_TurnoPruebaDeLaboratorio_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_turnoPruebaDeLaboratorio_PruebaDeLaboratorioId",
                table: "TurnoPruebaDeLaboratorio",
                newName: "IX_TurnoPruebaDeLaboratorio_PruebaDeLaboratorioId");

            migrationBuilder.RenameIndex(
                name: "IX_turno_EstadoTurnoId",
                table: "Turno",
                newName: "IX_Turno_EstadoTurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_EstadoReciboId",
                table: "Recibo",
                newName: "IX_Recibo_EstadoReciboId");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_CedulaUsuario",
                table: "Recibo",
                newName: "IX_Recibo_CedulaUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_CedulaMedico",
                table: "Recibo",
                newName: "IX_Recibo_CedulaMedico");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_CedulaCliente",
                table: "Recibo",
                newName: "IX_Recibo_CedulaCliente");

            migrationBuilder.RenameIndex(
                name: "IX_pruebaDeLaboratorioRecibo_ReciboId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "IX_PruebaDeLaboratorioRecibo_ReciboId");

            migrationBuilder.RenameIndex(
                name: "IX_pruebaDeLaboratorioRecibo_PruebaDeLaboratorioId",
                table: "PruebaDeLaboratorioRecibo",
                newName: "IX_PruebaDeLaboratorioRecibo_PruebaDeLaboratorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TurnoPruebaDeLaboratorio",
                table: "TurnoPruebaDeLaboratorio",
                column: "TurnoPruebaDeLaboratorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turno",
                table: "Turno",
                column: "TurnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recibo",
                table: "Recibo",
                column: "ReciboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PruebaDeLaboratorioRecibo",
                table: "PruebaDeLaboratorioRecibo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medico",
                table: "Medico",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoTurno",
                table: "EstadoTurno",
                column: "EstadoTurnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pruebaDeLaboratorios",
                table: "pruebaDeLaboratorios",
                column: "PruebaDeLaboratorioId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recibo_Cliente_CedulaCliente",
                table: "Recibo",
                column: "CedulaCliente",
                principalTable: "Cliente",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibo_Medico_CedulaMedico",
                table: "Recibo",
                column: "CedulaMedico",
                principalTable: "Medico",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibo_Usuario_CedulaUsuario",
                table: "Recibo",
                column: "CedulaUsuario",
                principalTable: "Usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibo_estadoRecibo_EstadoReciboId",
                table: "Recibo",
                column: "EstadoReciboId",
                principalTable: "estadoRecibo",
                principalColumn: "EstadoReciboId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_EstadoTurno_EstadoTurnoId",
                table: "Turno",
                column: "EstadoTurnoId",
                principalTable: "EstadoTurno",
                principalColumn: "EstadoTurnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TurnoPruebaDeLaboratorio_Turno_TurnoId",
                table: "TurnoPruebaDeLaboratorio",
                column: "TurnoId",
                principalTable: "Turno",
                principalColumn: "TurnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TurnoPruebaDeLaboratorio_pruebaDeLaboratorios_PruebaDeLaboratorioId",
                table: "TurnoPruebaDeLaboratorio",
                column: "PruebaDeLaboratorioId",
                principalTable: "pruebaDeLaboratorios",
                principalColumn: "PruebaDeLaboratorioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
