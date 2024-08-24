using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BrojKancelarija = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specijalizacija = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Formulari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MestoStanovanja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AdresaStanovanja = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PacijentID = table.Column<int>(type: "int", nullable: true),
                    ClanKlinikeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Formulari_Korisnici_ClanKlinikeID",
                        column: x => x.ClanKlinikeID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Formulari_Korisnici_PacijentID",
                        column: x => x.PacijentID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Kreator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzije_Korisnici_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formulari_ClanKlinikeID",
                table: "Formulari",
                column: "ClanKlinikeID");

            migrationBuilder.CreateIndex(
                name: "IX_Formulari_PacijentID",
                table: "Formulari",
                column: "PacijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_ClanID",
                table: "Recenzije",
                column: "ClanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formulari");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
