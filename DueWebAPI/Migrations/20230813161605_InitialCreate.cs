using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetenceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartementTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartementTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfesseurTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesseurTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapaciteTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapaciteTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapaciteTable_CompetenceTable_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "CompetenceTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursusTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Implentation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursusTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursusTable_DepartementTable_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "DepartementTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AATable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AATable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AATable_ProfesseurTable_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "ProfesseurTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UETable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UETable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UETable_CursusTable_CursusId",
                        column: x => x.CursusId,
                        principalTable: "CursusTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AATable_ProfesseurId",
                table: "AATable",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaciteTable_CompetenceId",
                table: "CapaciteTable",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CursusTable_DepartementId",
                table: "CursusTable",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_UETable_CursusId",
                table: "UETable",
                column: "CursusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AATable");

            migrationBuilder.DropTable(
                name: "CapaciteTable");

            migrationBuilder.DropTable(
                name: "UETable");

            migrationBuilder.DropTable(
                name: "ProfesseurTable");

            migrationBuilder.DropTable(
                name: "CompetenceTable");

            migrationBuilder.DropTable(
                name: "CursusTable");

            migrationBuilder.DropTable(
                name: "DepartementTable");
        }
    }
}
