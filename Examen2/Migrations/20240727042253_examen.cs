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
                name: "cliente",
                schema: "dbo",
                columns: table => new
                {
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numero_Identidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "datos_prestamo",
                schema: "dbo",
                columns: table => new
                {
                    id_prestamo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<float>(type: "real", nullable: false),
                    interes = table.Column<float>(type: "real", nullable: false),
                    plaza = table.Column<int>(type: "int", nullable: false),
                    fecha_desembolso = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    id_autor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datos_prestamo", x => x.id_prestamo);
                    table.ForeignKey(
                        name: "FK_datos_prestamo_cliente_id_autor",
                        column: x => x.id_autor,
                        principalSchema: "dbo",
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoPrestamos",
                columns: table => new
                {
                    id_amortizacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_prestamo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    no_cuota = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dias = table.Column<int>(type: "int", nullable: false),
                    interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    abono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuota_sin_svds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuota_con_svds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    saldo_principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoPrestamos", x => x.id_amortizacion);
                    table.ForeignKey(
                        name: "FK_InfoPrestamos_datos_prestamo_id_prestamo",
                        column: x => x.id_prestamo,
                        principalSchema: "dbo",
                        principalTable: "datos_prestamo",
                        principalColumn: "id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datos_prestamo_id_autor",
                schema: "dbo",
                table: "datos_prestamo",
                column: "id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_InfoPrestamos_id_prestamo",
                table: "InfoPrestamos",
                column: "id_prestamo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoPrestamos");

            migrationBuilder.DropTable(
                name: "datos_prestamo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "dbo");
        }
    }
}
