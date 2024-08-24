using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulari_Korisnici_PacijentID",
                table: "Formulari");

            migrationBuilder.DropIndex(
                name: "IX_Formulari_PacijentID",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "PacijentID",
                table: "Formulari");
        }
    }
}
