using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FKUsuarioCedulaARecibo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_UsuariosCedula",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "CedulaUsuario",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "UsuariosCedula",
                table: "recibo",
                newName: "UsuarioCedula");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_UsuariosCedula",
                table: "recibo",
                newName: "IX_recibo_UsuarioCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_UsuarioCedula",
                table: "recibo",
                column: "UsuarioCedula",
                principalTable: "usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_UsuarioCedula",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "UsuarioCedula",
                table: "recibo",
                newName: "UsuariosCedula");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_UsuarioCedula",
                table: "recibo",
                newName: "IX_recibo_UsuariosCedula");

            migrationBuilder.AddColumn<string>(
                name: "CedulaUsuario",
                table: "recibo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_recibo_usuario_UsuariosCedula",
                table: "recibo",
                column: "UsuariosCedula",
                principalTable: "usuario",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
