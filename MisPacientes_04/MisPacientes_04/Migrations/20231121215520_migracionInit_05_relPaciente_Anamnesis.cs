using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisPacientes_04.Migrations
{
    /// <inheritdoc />
    public partial class migracionInit_05_relPaciente_Anamnesis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnamnesisRefId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Anamnesis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    EnfermedadActual = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesis", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Anamnesis_AnamnesisRefId",
                table: "Paciente");

            migrationBuilder.DropTable(
                name: "Anamnesis");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_AnamnesisRefId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "AnamnesisRefId",
                table: "Paciente");
        }
    }
}
