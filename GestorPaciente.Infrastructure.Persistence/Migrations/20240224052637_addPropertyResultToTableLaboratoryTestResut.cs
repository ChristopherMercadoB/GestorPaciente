using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPaciente.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyResultToTableLaboratoryTestResut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Resultado",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Resultado");
        }
    }
}
