using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreDeEntidadUsuarioAUsuarioIdEnSuPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_Cedula",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "usuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "recibo",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_Cedula",
                table: "recibo",
                newName: "IX_recibo_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_UsuarioId",
                table: "recibo",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_UsuarioId",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "usuario",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "recibo",
                newName: "Cedula");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_UsuarioId",
                table: "recibo",
                newName: "IX_recibo_Cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_Cedula",
                table: "recibo",
                column: "Cedula",
                principalTable: "usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
