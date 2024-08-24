using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Cenovnik_CenovnikID",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluge_Cenovnik_CenovnikID",
                table: "Usluge");

            migrationBuilder.RenameColumn(
                name: "CenovnikID",
                table: "Usluge",
                newName: "cenovnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Usluge_CenovnikID",
                table: "Usluge",
                newName: "IX_Usluge_cenovnikID");

            migrationBuilder.RenameColumn(
                name: "CenovnikID",
                table: "Pregledi",
                newName: "UslugaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_CenovnikID",
                table: "Pregledi",
                newName: "IX_Pregledi_UslugaID");

            migrationBuilder.AddColumn<int>(
                name: "TipClana",
                table: "Korisnici",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Usluge_UslugaID",
                table: "Pregledi",
                column: "UslugaID",
                principalTable: "Usluge",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluge_Cenovnik_cenovnikID",
                table: "Usluge",
                column: "cenovnikID",
                principalTable: "Cenovnik",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Usluge_UslugaID",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluge_Cenovnik_cenovnikID",
                table: "Usluge");

            migrationBuilder.DropColumn(
                name: "TipClana",
                table: "Korisnici");

            migrationBuilder.RenameColumn(
                name: "cenovnikID",
                table: "Usluge",
                newName: "CenovnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Usluge_cenovnikID",
                table: "Usluge",
                newName: "IX_Usluge_CenovnikID");

            migrationBuilder.RenameColumn(
                name: "UslugaID",
                table: "Pregledi",
                newName: "CenovnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_UslugaID",
                table: "Pregledi",
                newName: "IX_Pregledi_CenovnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Cenovnik_CenovnikID",
                table: "Pregledi",
                column: "CenovnikID",
                principalTable: "Cenovnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluge_Cenovnik_CenovnikID",
                table: "Usluge",
                column: "CenovnikID",
                principalTable: "Cenovnik",
                principalColumn: "ID");
        }
    }
}
