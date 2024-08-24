using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulari_Korisnici_ClanKlinikeID",
                table: "Formulari");

            migrationBuilder.RenameColumn(
                name: "TipClana",
                table: "Korisnici",
                newName: "RadnoMestoID");

            migrationBuilder.RenameColumn(
                name: "ClanKlinikeID",
                table: "Formulari",
                newName: "RecepcijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Formulari_ClanKlinikeID",
                table: "Formulari",
                newName: "IX_Formulari_RecepcijaID");

            migrationBuilder.AddColumn<bool>(
                name: "Direktor",
                table: "Korisnici",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recepcije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcije", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_RadnoMestoID",
                table: "Korisnici",
                column: "RadnoMestoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulari_Recepcije_RecepcijaID",
                table: "Formulari",
                column: "RecepcijaID",
                principalTable: "Recepcije",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Recepcije_RadnoMestoID",
                table: "Korisnici",
                column: "RadnoMestoID",
                principalTable: "Recepcije",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulari_Recepcije_RecepcijaID",
                table: "Formulari");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Recepcije_RadnoMestoID",
                table: "Korisnici");

            migrationBuilder.DropTable(
                name: "Recepcije");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_RadnoMestoID",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Direktor",
                table: "Korisnici");

            migrationBuilder.RenameColumn(
                name: "RadnoMestoID",
                table: "Korisnici",
                newName: "TipClana");

            migrationBuilder.RenameColumn(
                name: "RecepcijaID",
                table: "Formulari",
                newName: "ClanKlinikeID");

            migrationBuilder.RenameIndex(
                name: "IX_Formulari_RecepcijaID",
                table: "Formulari",
                newName: "IX_Formulari_ClanKlinikeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulari_Korisnici_ClanKlinikeID",
                table: "Formulari",
                column: "ClanKlinikeID",
                principalTable: "Korisnici",
                principalColumn: "ID");
        }
    }
}
