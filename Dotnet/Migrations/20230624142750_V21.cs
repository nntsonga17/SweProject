using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Usluge_UslugaID",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Korisnici");

            migrationBuilder.RenameColumn(
                name: "UslugaID",
                table: "Pregledi",
                newName: "PacijentID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_UslugaID",
                table: "Pregledi",
                newName: "IX_Pregledi_PacijentID");

            migrationBuilder.AddColumn<DateTime>(
                name: "datumPregleda",
                table: "Formulari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClanKlinikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slike_Korisnici_ClanKlinikeId",
                        column: x => x.ClanKlinikeId,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ClanKlinikeId",
                table: "Slike",
                column: "ClanKlinikeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Korisnici_PacijentID",
                table: "Pregledi",
                column: "PacijentID",
                principalTable: "Korisnici",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Korisnici_PacijentID",
                table: "Pregledi");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropColumn(
                name: "datumPregleda",
                table: "Formulari");

            migrationBuilder.RenameColumn(
                name: "PacijentID",
                table: "Pregledi",
                newName: "UslugaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_PacijentID",
                table: "Pregledi",
                newName: "IX_Pregledi_UslugaID");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Korisnici",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Usluge_UslugaID",
                table: "Pregledi",
                column: "UslugaID",
                principalTable: "Usluge",
                principalColumn: "ID");
        }
    }
}
