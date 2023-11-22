using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MisPacientes_04.Migrations
{
    /// <inheritdoc />
    public partial class migracionInit_07_relAnamnesis_AntFam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntecedenteFamiliar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Cardios = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    E_Respiratorias = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    DescripcionAntecedentes = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    AnamnesisRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedenteFamiliar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedenteFamiliar_Anamnesis_AnamnesisRefId",
                        column: x => x.AnamnesisRefId,
                        principalTable: "Anamnesis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedenteFamiliar_AnamnesisRefId",
                table: "AntecedenteFamiliar",
                column: "AnamnesisRefId",
                unique: true,
                filter: "[AnamnesisRefId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntecedenteFamiliar");
        }
    }
}
