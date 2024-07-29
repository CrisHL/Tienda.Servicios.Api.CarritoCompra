using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.Servicios.Api.CarritoCompra.Migrations
{
    /// <inheritdoc />
    public partial class CarritoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carritoSesiones",
                columns: table => new
                {
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritoSesiones", x => x.CarritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalle",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoSeleccionado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalle", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalle_carritoSesiones_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "carritoSesiones",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalle_CarritoSesionId",
                table: "CarritoSesionDetalle",
                column: "CarritoSesionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalle");

            migrationBuilder.DropTable(
                name: "carritoSesiones");
        }
    }
}
