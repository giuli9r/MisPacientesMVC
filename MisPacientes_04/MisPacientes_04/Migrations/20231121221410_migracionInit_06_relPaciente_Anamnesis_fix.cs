using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisPacientes_04.Migrations
{
    /// <inheritdoc />
    public partial class migracionInit_06_relPaciente_Anamnesis_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Anamnesis_AnamnesisRefId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_AnamnesisRefId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "AnamnesisRefId",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "PacienteRefId",
                table: "Anamnesis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anamnesis_PacienteRefId",
                table: "Anamnesis",
                column: "PacienteRefId",
                unique: true,
                filter: "[PacienteRefId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Anamnesis_Paciente_PacienteRefId",
                table: "Anamnesis",
                column: "PacienteRefId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anamnesis_Paciente_PacienteRefId",
                table: "Anamnesis");

            migrationBuilder.DropIndex(
                name: "IX_Anamnesis_PacienteRefId",
                table: "Anamnesis");

            migrationBuilder.DropColumn(
                name: "PacienteRefId",
                table: "Anamnesis");

            migrationBuilder.AddColumn<int>(
                name: "AnamnesisRefId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_AnamnesisRefId",
                table: "Paciente",
                column: "AnamnesisRefId",
                unique: true,
                filter: "[AnamnesisRefId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Anamnesis_AnamnesisRefId",
                table: "Paciente",
                column: "AnamnesisRefId",
                principalTable: "Anamnesis",
                principalColumn: "Id");
        }
    }
}
