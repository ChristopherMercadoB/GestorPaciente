using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPaciente.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class setDeleteBehaviors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Medico_DoctorId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_PatientId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Medico_DoctorId",
                table: "Cita",
                column: "DoctorId",
                principalTable: "Medico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_PatientId",
                table: "Cita",
                column: "PatientId",
                principalTable: "Paciente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado",
                column: "DateId",
                principalTable: "Cita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Medico_DoctorId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_PatientId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Medico_DoctorId",
                table: "Cita",
                column: "DoctorId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_PatientId",
                table: "Cita",
                column: "PatientId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Cita_DateId",
                table: "Resultado",
                column: "DateId",
                principalTable: "Cita",
                principalColumn: "Id");
        }
    }
}
