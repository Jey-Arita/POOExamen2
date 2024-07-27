using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen2.Migrations
{
    /// <inheritdoc />
    public partial class examen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "datos_prestamo",
                schema: "dbo",
                columns: table => new
                {
                    id_prestamo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    duracion_prestamo = table.Column<int>(type: "int", nullable: false),
                    interes = table.Column<float>(type: "real", nullable: false),
                    abono = table.Column<float>(type: "real", nullable: false),
                    cuotas = table.Column<float>(type: "real", nullable: false),
                    capital_total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datos_prestamo", x => x.id_prestamo);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numero_Identidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_autor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_datos_prestamo_id_autor",
                        column: x => x.id_autor,
                        principalSchema: "dbo",
                        principalTable: "datos_prestamo",
                        principalColumn: "id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_id_autor",
                schema: "dbo",
                table: "cliente",
                column: "id_autor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "datos_prestamo",
                schema: "dbo");
        }
    }
}
