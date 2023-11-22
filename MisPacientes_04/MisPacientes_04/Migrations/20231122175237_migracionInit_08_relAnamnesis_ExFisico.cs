using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisPacientes_04.Migrations
{
    /// <inheritdoc />
    public partial class migracionInit_08_relAnamnesis_ExFisico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamenFisico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImagenExamenFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AnamnesisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenFisico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenFisico_Anamnesis_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamenFisico_AnamnesisId",
                table: "ExamenFisico",
                column: "AnamnesisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenFisico");
        }
    }
}
