using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPaciente.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class propertiesAndForeignKeysAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "Resultado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_DateId",
                table: "Resultado",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado",
                column: "DateId",
                principalTable: "Cita",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Resultado_DateId",
                table: "Resultado");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Resultado");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
