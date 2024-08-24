using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenovnikID",
                table: "Pregledi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_CenovnikID",
                table: "Pregledi",
                column: "CenovnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Cenovnik_CenovnikID",
                table: "Pregledi",
                column: "CenovnikID",
                principalTable: "Cenovnik",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Cenovnik_CenovnikID",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_CenovnikID",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "CenovnikID",
                table: "Pregledi");
        }
    }
}
