using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2Laboratorio.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifiqueUnaEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "cliente",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "cliente");
        }
    }
}
