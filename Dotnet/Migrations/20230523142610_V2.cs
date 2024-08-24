using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dijagnoza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LekarID = table.Column<int>(type: "int", nullable: true),
                    PacijentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pregledi_Korisnici_LekarID",
                        column: x => x.LekarID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pregledi_Korisnici_PacijentID",
                        column: x => x.PacijentID,
                        principalTable: "Korisnici",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_LekarID",
                table: "Pregledi",
                column: "LekarID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_PacijentID",
                table: "Pregledi",
                column: "PacijentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pregledi");
        }
    }
}
