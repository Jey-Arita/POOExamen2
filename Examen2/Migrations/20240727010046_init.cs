using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "cliente",
                newName: "id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_cliente",
                schema: "dbo",
                table: "cliente",
                newName: "id");
        }
    }
}
