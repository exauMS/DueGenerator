using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableFiche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapaciteTable_CompetenceTable_CompetenceId",
                table: "CapaciteTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CursusTable_DepartementTable_DepartementId",
                table: "CursusTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UETable_CursusTable_CursusId",
                table: "UETable");

            migrationBuilder.DropIndex(
                name: "IX_UETable_CursusId",
                table: "UETable");

            migrationBuilder.DropIndex(
                name: "IX_CursusTable_DepartementId",
                table: "CursusTable");

            migrationBuilder.DropIndex(
                name: "IX_CapaciteTable_CompetenceId",
                table: "CapaciteTable");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "FicheTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annee",
                table: "FicheTable");

            migrationBuilder.CreateIndex(
                name: "IX_UETable_CursusId",
                table: "UETable",
                column: "CursusId");

            migrationBuilder.CreateIndex(
                name: "IX_CursusTable_DepartementId",
                table: "CursusTable",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaciteTable_CompetenceId",
                table: "CapaciteTable",
                column: "CompetenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapaciteTable_CompetenceTable_CompetenceId",
                table: "CapaciteTable",
                column: "CompetenceId",
                principalTable: "CompetenceTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursusTable_DepartementTable_DepartementId",
                table: "CursusTable",
                column: "DepartementId",
                principalTable: "DepartementTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UETable_CursusTable_CursusId",
                table: "UETable",
                column: "CursusId",
                principalTable: "CursusTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
