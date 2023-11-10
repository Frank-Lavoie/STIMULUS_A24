using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    CodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursId);
                });

            migrationBuilder.CreateTable(
                name: "Exercice",
                columns: table => new
                {
                    ExerciceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercice", x => x.ExerciceId);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longueur = table.Column<int>(type: "int", nullable: false),
                    Largeur = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Importance",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Pts = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importance", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "TexteFormater",
                columns: table => new
                {
                    TexteFormaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TexteFormater", x => x.TexteFormaterId);
                });

            migrationBuilder.CreateTable(
                name: "TokenInfo",
                columns: table => new
                {
                    TokenInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenInfo", x => x.TokenInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Identifiant = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longueur = table.Column<int>(type: "int", nullable: false),
                    Largeur = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "FichierSource",
                columns: table => new
                {
                    FichierSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MiseEnSituation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierSource", x => x.FichierSourceId);
                    table.ForeignKey(
                        name: "FK_FichierSource_Exercice_ExerciceId",
                        column: x => x.ExerciceId,
                        principalTable: "Exercice",
                        principalColumn: "ExerciceId");
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Identifiant = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Etudiant_Utilisateur_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Utilisateur",
                        principalColumn: "Identifiant");
                });

            migrationBuilder.CreateTable(
                name: "Professeur",
                columns: table => new
                {
                    Identifiant = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeur", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Professeur_Utilisateur_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Utilisateur",
                        principalColumn: "Identifiant");
                });

            migrationBuilder.CreateTable(
                name: "FichierSauvegarde",
                columns: table => new
                {
                    FichierSauvegardeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Contenue = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Version = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeDA = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierSauvegarde", x => x.FichierSauvegardeId);
                    table.ForeignKey(
                        name: "FK_FichierSauvegarde_Etudiant_CodeDA",
                        column: x => x.CodeDA,
                        principalTable: "Etudiant",
                        principalColumn: "Identifiant");
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "Date", nullable: false),
                    DateCloture = table.Column<DateTime>(type: "Date", nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: true),
                    ProfesseurId = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.GroupeId);
                    table.ForeignKey(
                        name: "FK_Groupe_Cours_CoursId",
                        column: x => x.CoursId,
                        principalTable: "Cours",
                        principalColumn: "CoursId");
                    table.ForeignKey(
                        name: "FK_Groupe_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "Identifiant");
                });

            migrationBuilder.CreateTable(
                name: "Graphe",
                columns: table => new
                {
                    GrapheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(55)", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graphe", x => x.GrapheId);
                    table.ForeignKey(
                        name: "FK_Graphe_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "GroupeId");
                });

            migrationBuilder.CreateTable(
                name: "Groupe_Etudiant",
                columns: table => new
                {
                    Groupe_EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeId = table.Column<int>(type: "int", nullable: true),
                    CodeDA = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe_Etudiant", x => x.Groupe_EtudiantId);
                    table.ForeignKey(
                        name: "FK_Groupe_Etudiant_Etudiant_CodeDA",
                        column: x => x.CodeDA,
                        principalTable: "Etudiant",
                        principalColumn: "Identifiant");
                    table.ForeignKey(
                        name: "FK_Groupe_Etudiant_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "GroupeId");
                });

            migrationBuilder.CreateTable(
                name: "Noeud",
                columns: table => new
                {
                    NoeudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Disponibilite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obligatoire = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PosX = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PosY = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Rayon = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GrapheId = table.Column<int>(type: "int", nullable: true),
                    NoeudParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noeud", x => x.NoeudId);
                    table.ForeignKey(
                        name: "FK_Noeud_Graphe_GrapheId",
                        column: x => x.GrapheId,
                        principalTable: "Graphe",
                        principalColumn: "GrapheId");
                    table.ForeignKey(
                        name: "FK_Noeud_Noeud_NoeudParentId",
                        column: x => x.NoeudParentId,
                        principalTable: "Noeud",
                        principalColumn: "NoeudId");
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    NoeudId = table.Column<int>(type: "int", nullable: true),
                    ImportanceId = table.Column<string>(type: "char(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_Page_Importance_ImportanceId",
                        column: x => x.ImportanceId,
                        principalTable: "Importance",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Page_Noeud_NoeudId",
                        column: x => x.NoeudId,
                        principalTable: "Noeud",
                        principalColumn: "NoeudId");
                });

            migrationBuilder.CreateTable(
                name: "Composant",
                columns: table => new
                {
                    ComposantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordre = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composant", x => x.ComposantId);
                    table.ForeignKey(
                        name: "FK_Composant_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "PageId");
                });

            migrationBuilder.CreateTable(
                name: "Page_Etudiant",
                columns: table => new
                {
                    Page_EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "Date", nullable: false),
                    DateFin = table.Column<DateTime>(type: "Date", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: true),
                    CodeDA = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_Etudiant", x => x.Page_EtudiantId);
                    table.ForeignKey(
                        name: "FK_Page_Etudiant_Etudiant_CodeDA",
                        column: x => x.CodeDA,
                        principalTable: "Etudiant",
                        principalColumn: "Identifiant");
                    table.ForeignKey(
                        name: "FK_Page_Etudiant_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "PageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Composant_PageId",
                table: "Composant",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_FichierSauvegarde_CodeDA",
                table: "FichierSauvegarde",
                column: "CodeDA");

            migrationBuilder.CreateIndex(
                name: "IX_FichierSource_ExerciceId",
                table: "FichierSource",
                column: "ExerciceId");

            migrationBuilder.CreateIndex(
                name: "IX_Graphe_GroupeId",
                table: "Graphe",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_CoursId",
                table: "Groupe",
                column: "CoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_ProfesseurId",
                table: "Groupe",
                column: "ProfesseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_Etudiant_CodeDA",
                table: "Groupe_Etudiant",
                column: "CodeDA");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_Etudiant_GroupeId",
                table: "Groupe_Etudiant",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Noeud_GrapheId",
                table: "Noeud",
                column: "GrapheId");

            migrationBuilder.CreateIndex(
                name: "IX_Noeud_NoeudParentId",
                table: "Noeud",
                column: "NoeudParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_ImportanceId",
                table: "Page",
                column: "ImportanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_NoeudId",
                table: "Page",
                column: "NoeudId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Etudiant_CodeDA",
                table: "Page_Etudiant",
                column: "CodeDA");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Etudiant_PageId",
                table: "Page_Etudiant",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Composant");

            migrationBuilder.DropTable(
                name: "FichierSauvegarde");

            migrationBuilder.DropTable(
                name: "FichierSource");

            migrationBuilder.DropTable(
                name: "Groupe_Etudiant");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Page_Etudiant");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "TexteFormater");

            migrationBuilder.DropTable(
                name: "TokenInfo");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Exercice");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Importance");

            migrationBuilder.DropTable(
                name: "Noeud");

            migrationBuilder.DropTable(
                name: "Graphe");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Professeur");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
