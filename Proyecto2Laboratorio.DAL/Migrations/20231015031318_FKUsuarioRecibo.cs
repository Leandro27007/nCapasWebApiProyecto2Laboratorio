using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FKUsuarioRecibo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CedulaUsuario",
                table: "recibo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedulaUsuario",
                table: "recibo");
        }
    }
}
