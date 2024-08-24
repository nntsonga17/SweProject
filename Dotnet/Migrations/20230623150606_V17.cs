using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Formulari_FormularID",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Korisnici_LekarID",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluge_Cenovnik_cenovnikID",
                table: "Usluge");

            migrationBuilder.DropTable(
                name: "Cenovnik");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropIndex(
                name: "IX_Usluge_cenovnikID",
                table: "Usluge");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_FormularID",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "cenovnikID",
                table: "Usluge");

            migrationBuilder.DropColumn(
                name: "FormularID",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "AdresaStanovanja",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "MestoStanovanja",
                table: "Formulari");

            migrationBuilder.RenameColumn(
                name: "LekarID",
                table: "Pregledi",
                newName: "DoktorID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_LekarID",
                table: "Pregledi",
                newName: "IX_Pregledi_DoktorID");

            migrationBuilder.AddColumn<string>(
                name: "Alergije",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Korisnici",
                type: "datetime2",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HronicneBolesti",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KucnaAdresa",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Formulari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formulari_DoktorID",
                table: "Formulari",
                column: "DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulari_Korisnici_DoktorID",
                table: "Formulari",
                column: "DoktorID",
                principalTable: "Korisnici",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Korisnici_DoktorID",
                table: "Pregledi",
                column: "DoktorID",
                principalTable: "Korisnici",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulari_Korisnici_DoktorID",
                table: "Formulari");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Korisnici_DoktorID",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Formulari_DoktorID",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "Alergije",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "HronicneBolesti",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "KucnaAdresa",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Formulari");

            migrationBuilder.RenameColumn(
                name: "DoktorID",
                table: "Pregledi",
                newName: "LekarID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_DoktorID",
                table: "Pregledi",
                newName: "IX_Pregledi_LekarID");

            migrationBuilder.AddColumn<int>(
                name: "cenovnikID",
                table: "Usluge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormularID",
                table: "Pregledi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresaStanovanja",
                table: "Formulari",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Formulari",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MestoStanovanja",
                table: "Formulari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cenovnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cenovnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kreator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_Usluge_cenovnikID",
                table: "Usluge",
                column: "cenovnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_FormularID",
                table: "Pregledi",
                column: "FormularID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_ClanID",
                table: "Recenzije",
                column: "ClanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Formulari_FormularID",
                table: "Pregledi",
                column: "FormularID",
                principalTable: "Formulari",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Korisnici_LekarID",
                table: "Pregledi",
                column: "LekarID",
                principalTable: "Korisnici",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluge_Cenovnik_cenovnikID",
                table: "Usluge",
                column: "cenovnikID",
                principalTable: "Cenovnik",
                principalColumn: "ID");
        }
    }
}
