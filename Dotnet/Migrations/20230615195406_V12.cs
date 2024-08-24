using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "Formulari",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Formulari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Formulari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Formulari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Formulari");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Formulari");
        }
    }
}
