using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AATable_ProfesseurTable_ProfesseurId",
                table: "AATable");

            migrationBuilder.DropIndex(
                name: "IX_AATable_ProfesseurId",
                table: "AATable");

            migrationBuilder.DropColumn(
                name: "ProfesseurId",
                table: "AATable");

            migrationBuilder.AddColumn<string>(
                name: "Professeur",
                table: "AATable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Professeur",
                table: "AATable");

            migrationBuilder.AddColumn<int>(
                name: "ProfesseurId",
                table: "AATable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AATable_ProfesseurId",
                table: "AATable",
                column: "ProfesseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_AATable_ProfesseurTable_ProfesseurId",
                table: "AATable",
                column: "ProfesseurId",
                principalTable: "ProfesseurTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
