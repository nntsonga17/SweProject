using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImeIPrezime",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Korisnici");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Korisnici",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Korisnici",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Korisnici");

            migrationBuilder.AddColumn<string>(
                name: "ImeIPrezime",
                table: "Korisnici",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
