using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPaciente.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changePropertyLaboratoryTestIdToNulleable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryTestId",
                table: "Resultado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LaboratoryTestId",
                table: "Resultado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
