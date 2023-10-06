using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FicheTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FicheTable",
                columns: table => new
                {
                    FicheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cursus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orientation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Implantation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumSecretariat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bloc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quadrimestre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauCertification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UEPrerequis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UECorequis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolHoraire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangueEnseignement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangueEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsableUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitulaireAA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Competences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acquis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContenuSynthetique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodeApprentissage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportCours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalculNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheTable", x => x.FicheId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FicheTable");
        }
    }
}
