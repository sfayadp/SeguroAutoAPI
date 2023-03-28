using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguroAutoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroPoliza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificacionCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimientoCliente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicioPoliza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinPoliza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMaximoCubierto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombrePlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacaAutomotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloAutomotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoTieneInspeccion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coberturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoCubierto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolizaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coberturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coberturas_Polizas_PolizaId",
                        column: x => x.PolizaId,
                        principalTable: "Polizas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coberturas_PolizaId",
                table: "Coberturas",
                column: "PolizaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coberturas");

            migrationBuilder.DropTable(
                name: "Polizas");
        }
    }
}
