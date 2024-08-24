using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulari_Korisnici_PacijentID",
                table: "Formulari");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Korisnici_PacijentID",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Formulari_PacijentID",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "PacijentID",
                table: "Formulari");

            migrationBuilder.RenameColumn(
                name: "PacijentID",
                table: "Pregledi",
                newName: "FormularID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_PacijentID",
                table: "Pregledi",
                newName: "IX_Pregledi_FormularID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Formulari_FormularID",
                table: "Pregledi",
                column: "FormularID",
                principalTable: "Formulari",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Formulari_FormularID",
                table: "Pregledi");

            migrationBuilder.RenameColumn(
                name: "FormularID",
                table: "Pregledi",
                newName: "PacijentID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_FormularID",
                table: "Pregledi",
                newName: "IX_Pregledi_PacijentID");

            migrationBuilder.AddColumn<int>(
                name: "PacijentID",
                table: "Formulari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formulari_PacijentID",
                table: "Formulari",
                column: "PacijentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulari_Korisnici_PacijentID",
                table: "Formulari",
                column: "PacijentID",
                principalTable: "Korisnici",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Korisnici_PacijentID",
                table: "Pregledi",
                column: "PacijentID",
                principalTable: "Korisnici",
                principalColumn: "ID");
        }
    }
}
