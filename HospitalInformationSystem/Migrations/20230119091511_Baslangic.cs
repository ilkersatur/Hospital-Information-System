using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class Baslangic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gunler",
                columns: table => new
                {
                    GunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gunler", x => x.GunID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikID);
                });

            migrationBuilder.CreateTable(
                name: "Saatler",
                columns: table => new
                {
                    SaatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuSaati = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saatler", x => x.SaatID);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biyografi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RandevuTanimlari",
                columns: table => new
                {
                    RandevuTanimiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikID = table.Column<int>(type: "int", nullable: false),
                    GunID = table.Column<int>(type: "int", nullable: false),
                    SaatID = table.Column<int>(type: "int", nullable: false),
                    RandevuDurumu = table.Column<bool>(type: "bit", nullable: false),
                    RandevuTanimiID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuTanimlari", x => x.RandevuTanimiID);
                    table.ForeignKey(
                        name: "FK_RandevuTanimlari_Gunler_GunID",
                        column: x => x.GunID,
                        principalTable: "Gunler",
                        principalColumn: "GunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandevuTanimlari_RandevuTanimlari_RandevuTanimiID1",
                        column: x => x.RandevuTanimiID1,
                        principalTable: "RandevuTanimlari",
                        principalColumn: "RandevuTanimiID");
                    table.ForeignKey(
                        name: "FK_RandevuTanimlari_Saatler_SaatID",
                        column: x => x.SaatID,
                        principalTable: "Saatler",
                        principalColumn: "SaatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArkaKapakYazisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KapakResmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onerilen = table.Column<bool>(type: "bit", nullable: false),
                    OduncVerildi = table.Column<bool>(type: "bit", nullable: false),
                    StokAdedi = table.Column<int>(type: "int", nullable: false),
                    OrtalamaPuan = table.Column<double>(type: "float", nullable: false),
                    EklendigiTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    RandevuTanimiID = table.Column<int>(type: "int", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UyeGeldiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Randevular_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_RandevuTanimlari_RandevuTanimiID",
                        column: x => x.RandevuTanimiID,
                        principalTable: "RandevuTanimlari",
                        principalColumn: "RandevuTanimiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitap_Kategori",
                columns: table => new
                {
                    KKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    Kitap_KategoriKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitap_Kategori", x => x.KKID);
                    table.ForeignKey(
                        name: "FK_Kitap_Kategori_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Kategori_Kitap_Kategori_Kitap_KategoriKKID",
                        column: x => x.Kitap_KategoriKKID,
                        principalTable: "Kitap_Kategori",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Kitap_Kategori_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OduncVerme",
                columns: table => new
                {
                    OduncVermeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    VerilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VarsayilanTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kitap_KategoriKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OduncVerme", x => x.OduncVermeID);
                    table.ForeignKey(
                        name: "FK_OduncVerme_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OduncVerme_Kitap_Kategori_Kitap_KategoriKKID",
                        column: x => x.Kitap_KategoriKKID,
                        principalTable: "Kitap_Kategori",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_OduncVerme_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puanlar",
                columns: table => new
                {
                    PuanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    Puanlama = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kitap_KategoriKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puanlar", x => x.PuanID);
                    table.ForeignKey(
                        name: "FK_Puanlar_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puanlar_Kitap_Kategori_Kitap_KategoriKKID",
                        column: x => x.Kitap_KategoriKKID,
                        principalTable: "Kitap_Kategori",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Puanlar_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Kitap_KategoriKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sepetler_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepetler_Kitap_Kategori_Kitap_KategoriKKID",
                        column: x => x.Kitap_KategoriKKID,
                        principalTable: "Kitap_Kategori",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Sepetler_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YorumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kitap_KategoriKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumID);
                    table.ForeignKey(
                        name: "FK_Yorumlar_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kitap_Kategori_Kitap_KategoriKKID",
                        column: x => x.Kitap_KategoriKKID,
                        principalTable: "Kitap_Kategori",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gunler",
                columns: new[] { "GunID", "GunAdi" },
                values: new object[,]
                {
                    { 1, "Pazartesi" },
                    { 2, "Salı" },
                    { 3, "Çarşamba" },
                    { 4, "Perşembe" },
                    { 5, "Cuma" }
                });

            migrationBuilder.InsertData(
                table: "Poliklinikler",
                columns: new[] { "PoliklinikID", "PoliklinikAdi", "Resim" },
                values: new object[,]
                {
                    { 1, "Kulak Burun Boğaz", "resim1.jpg" },
                    { 2, "Genel Cerrahi", "resim2.jpg" },
                    { 3, "Göz", "resim3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Saatler",
                columns: new[] { "SaatID", "RandevuSaati" },
                values: new object[,]
                {
                    { 1, "10" },
                    { 2, "11" },
                    { 3, "12" },
                    { 4, "13" },
                    { 5, "14" },
                    { 6, "15" },
                    { 7, "16" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_Kategori_KategoriID",
                table: "Kitap_Kategori",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_Kategori_Kitap_KategoriKKID",
                table: "Kitap_Kategori",
                column: "Kitap_KategoriKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_Kategori_KitapID",
                table: "Kitap_Kategori",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarID",
                table: "Kitaplar",
                column: "YazarID");

            migrationBuilder.CreateIndex(
                name: "IX_OduncVerme_Kitap_KategoriKKID",
                table: "OduncVerme",
                column: "Kitap_KategoriKKID");

            migrationBuilder.CreateIndex(
                name: "IX_OduncVerme_KitapID",
                table: "OduncVerme",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_OduncVerme_UyeID",
                table: "OduncVerme",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_PoliklinikRandevuTanimi_RandevularTanimlariRandevuTanimiID",
                table: "PoliklinikRandevuTanimi",
                column: "RandevularTanimlariRandevuTanimiID");

            migrationBuilder.CreateIndex(
                name: "IX_Puanlar_Kitap_KategoriKKID",
                table: "Puanlar",
                column: "Kitap_KategoriKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Puanlar_KitapID",
                table: "Puanlar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Puanlar_UyeID",
                table: "Puanlar",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_RandevuTanimiID",
                table: "Randevular",
                column: "RandevuTanimiID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_UyeID",
                table: "Randevular",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuTanimlari_GunID",
                table: "RandevuTanimlari",
                column: "GunID");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuTanimlari_RandevuTanimiID1",
                table: "RandevuTanimlari",
                column: "RandevuTanimiID1");

            migrationBuilder.CreateIndex(
                name: "IX_RandevuTanimlari_SaatID",
                table: "RandevuTanimlari",
                column: "SaatID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_Kitap_KategoriKKID",
                table: "Sepetler",
                column: "Kitap_KategoriKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_KitapID",
                table: "Sepetler",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_UyeID",
                table: "Sepetler",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Kitap_KategoriKKID",
                table: "Yorumlar",
                column: "Kitap_KategoriKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KitapID",
                table: "Yorumlar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_UyeID",
                table: "Yorumlar",
                column: "UyeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OduncVerme");

            migrationBuilder.DropTable(
                name: "PoliklinikRandevuTanimi");

            migrationBuilder.DropTable(
                name: "Puanlar");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Sepetler");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "RandevuTanimlari");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kitap_Kategori");

            migrationBuilder.DropTable(
                name: "Gunler");

            migrationBuilder.DropTable(
                name: "Saatler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
