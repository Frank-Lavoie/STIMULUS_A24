using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    public partial class NomDeVotreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contenue",
                table: "Code",
                newName: "Contenu");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Noeud_Etudiant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contenu",
                table: "Code",
                newName: "Contenue");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Noeud_Etudiant",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
