using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atrasos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtrasoAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atraso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(128)", maxLength: 128, nullable: false),
                    Permiso = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    FechaHora = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "getdate()"),
                    Valor = table.Column<decimal>(type: "DECIMAL(19,2)", precision: 19, scale: 2, nullable: false),
                    EstadoDeuda = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    EsActivo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    Creado = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "getdate()"),
                    Actualizado = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atraso", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atraso");
        }
    }
}
