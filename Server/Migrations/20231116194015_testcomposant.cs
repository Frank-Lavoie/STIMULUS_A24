using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    public partial class testcomposant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Page");

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "Video",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "TexteFormater",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "Reference",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "Image",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "Exercice",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposantId",
                table: "Code",
                type: "char(3)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_ComposantId",
                table: "Video",
                column: "ComposantId");

            migrationBuilder.CreateIndex(
                name: "IX_TexteFormater_ComposantId",
                table: "TexteFormater",
                column: "ComposantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ComposantId",
                table: "Reference",
                column: "ComposantId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ComposantId",
                table: "Image",
                column: "ComposantId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercice_ComposantId",
                table: "Exercice",
                column: "ComposantId");

            migrationBuilder.CreateIndex(
                name: "IX_Code_ComposantId",
                table: "Code",
                column: "ComposantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Code_Importance_ComposantId",
                table: "Code",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercice_Importance_ComposantId",
                table: "Exercice",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Importance_ComposantId",
                table: "Image",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Reference_Importance_ComposantId",
                table: "Reference",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TexteFormater_Importance_ComposantId",
                table: "TexteFormater",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Importance_ComposantId",
                table: "Video",
                column: "ComposantId",
                principalTable: "Importance",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Code_Importance_ComposantId",
                table: "Code");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercice_Importance_ComposantId",
                table: "Exercice");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Importance_ComposantId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Reference_Importance_ComposantId",
                table: "Reference");

            migrationBuilder.DropForeignKey(
                name: "FK_TexteFormater_Importance_ComposantId",
                table: "TexteFormater");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Importance_ComposantId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_ComposantId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_TexteFormater_ComposantId",
                table: "TexteFormater");

            migrationBuilder.DropIndex(
                name: "IX_Reference_ComposantId",
                table: "Reference");

            migrationBuilder.DropIndex(
                name: "IX_Image_ComposantId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Exercice_ComposantId",
                table: "Exercice");

            migrationBuilder.DropIndex(
                name: "IX_Code_ComposantId",
                table: "Code");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "TexteFormater");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "Reference");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "Exercice");

            migrationBuilder.DropColumn(
                name: "ComposantId",
                table: "Code");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Page",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
