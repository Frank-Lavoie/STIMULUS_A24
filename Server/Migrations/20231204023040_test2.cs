using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noeud_Etudiant",
                columns: table => new
                {
                    Noeud_EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CodeDA = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NoeudId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noeud_Etudiant", x => x.Noeud_EtudiantId);
                    table.ForeignKey(
                        name: "FK_Noeud_Etudiant_Etudiant_CodeDA",
                        column: x => x.CodeDA,
                        principalTable: "Etudiant",
                        principalColumn: "Identifiant");
                    table.ForeignKey(
                        name: "FK_Noeud_Etudiant_Noeud_NoeudId",
                        column: x => x.NoeudId,
                        principalTable: "Noeud",
                        principalColumn: "NoeudId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noeud_Etudiant_CodeDA",
                table: "Noeud_Etudiant",
                column: "CodeDA");

            migrationBuilder.CreateIndex(
                name: "IX_Noeud_Etudiant_NoeudId",
                table: "Noeud_Etudiant",
                column: "NoeudId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noeud_Etudiant");
        }
    }
}
