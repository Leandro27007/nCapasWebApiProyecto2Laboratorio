using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class quiteRelacionMuchoMuchoDeReciboYUsuario_AgregueCampoEnReciboSobreElUltimoUsuarioQueModifico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_estadoRecibo_EstadoReciboId",
                table: "recibo");

            migrationBuilder.DropTable(
                name: "estadoRecibo");

            migrationBuilder.DropTable(
                name: "usuarioRecibo");

            migrationBuilder.DropIndex(
                name: "IX_recibo_EstadoReciboId",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "EstadoReciboId",
                table: "recibo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Descuento",
                table: "recibo",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "recibo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdUltimoUsuarioQueModifico",
                table: "recibo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotaDeModificacion",
                table: "recibo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosCedula",
                table: "recibo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_UsuariosCedula",
                table: "recibo",
                column: "UsuariosCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_UsuariosCedula",
                table: "recibo",
                column: "UsuariosCedula",
                principalTable: "usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_UsuariosCedula",
                table: "recibo");

            migrationBuilder.DropIndex(
                name: "IX_recibo_UsuariosCedula",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "IdUltimoUsuarioQueModifico",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "NotaDeModificacion",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "UsuariosCedula",
                table: "recibo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Descuento",
                table: "recibo",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReciboId",
                table: "recibo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "estadoRecibo",
                columns: table => new
                {
                    EstadoReciboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoRecibo", x => x.EstadoReciboId);
                });

            migrationBuilder.CreateTable(
                name: "usuarioRecibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboId1 = table.Column<int>(type: "int", nullable: false),
                    UsuarioCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IX_recibo_EstadoReciboId",
                table: "recibo",
                column: "EstadoReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRecibo_ReciboId1",
                table: "usuarioRecibo",
                column: "ReciboId1");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRecibo_UsuarioCedula",
                table: "usuarioRecibo",
                column: "UsuarioCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_estadoRecibo_EstadoReciboId",
                table: "recibo",
                column: "EstadoReciboId",
                principalTable: "estadoRecibo",
                principalColumn: "EstadoReciboId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
