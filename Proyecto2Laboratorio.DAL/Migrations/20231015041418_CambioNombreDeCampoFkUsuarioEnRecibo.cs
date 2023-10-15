using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreDeCampoFkUsuarioEnRecibo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_UsuarioCedula",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "UsuarioCedula",
                table: "recibo",
                newName: "Cedula");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_UsuarioCedula",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recibo_usuario_Cedula",
                table: "recibo");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "recibo",
                newName: "UsuarioCedula");

            migrationBuilder.RenameIndex(
                name: "IX_recibo_Cedula",
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
    }
}
