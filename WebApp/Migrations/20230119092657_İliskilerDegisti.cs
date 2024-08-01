using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class İliskilerDegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliklinikRandevuTanimi");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuTanimlari_PoliklinikID",
                table: "RandevuTanimlari",
                column: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_RandevuTanimlari_Poliklinikler_PoliklinikID",
                table: "RandevuTanimlari",
                column: "PoliklinikID",
                principalTable: "Poliklinikler",
                principalColumn: "PoliklinikID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandevuTanimlari_Poliklinikler_PoliklinikID",
                table: "RandevuTanimlari");

            migrationBuilder.DropIndex(
                name: "IX_RandevuTanimlari_PoliklinikID",
                table: "RandevuTanimlari");

            migrationBuilder.CreateTable(
                name: "PoliklinikRandevuTanimi",
                columns: table => new
                {
                    PolikliniklerPoliklinikID = table.Column<int>(type: "int", nullable: false),
                    RandevularTanimlariRandevuTanimiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliklinikRandevuTanimi", x => new { x.PolikliniklerPoliklinikID, x.RandevularTanimlariRandevuTanimiID });
                    table.ForeignKey(
                        name: "FK_PoliklinikRandevuTanimi_Poliklinikler_PolikliniklerPoliklinikID",
                        column: x => x.PolikliniklerPoliklinikID,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliklinikRandevuTanimi_RandevuTanimlari_RandevularTanimlariRandevuTanimiID",
                        column: x => x.RandevularTanimlariRandevuTanimiID,
                        principalTable: "RandevuTanimlari",
                        principalColumn: "RandevuTanimiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliklinikRandevuTanimi_RandevularTanimlariRandevuTanimiID",
                table: "PoliklinikRandevuTanimi",
                column: "RandevularTanimlariRandevuTanimiID");
        }
    }
}
