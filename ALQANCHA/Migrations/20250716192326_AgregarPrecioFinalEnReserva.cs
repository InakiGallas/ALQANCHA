using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALQANCHA.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPrecioFinalEnReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrecioFinal",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioFinal",
                table: "Reservas");
        }
    }
}
