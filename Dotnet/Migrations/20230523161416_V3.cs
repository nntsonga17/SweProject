using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Usluge",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaUsluge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OpisUsluge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CenaUsluge = table.Column<int>(type: "int", nullable: false),
                    CenovnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usluge_Cenovnik_CenovnikID",
                        column: x => x.CenovnikID,
                        principalTable: "Cenovnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_CenovnikID",
                table: "Usluge",
                column: "CenovnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Cenovnik");
        }
    }
}
