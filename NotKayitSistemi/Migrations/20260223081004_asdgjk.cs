using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotKayitSistemi.Migrations
{
    /// <inheritdoc />
    public partial class asdgjk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DersAlanKodTml",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersAlanKodTml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotKodTml",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotKodTml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciTml",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciTml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DersTml",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DersAlanKodId = table.Column<long>(type: "bigint", nullable: false),
                    KrediSayisi = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersTml", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DersTml_DersAlanKodTml_DersAlanKodId",
                        column: x => x.DersAlanKodId,
                        principalTable: "DersAlanKodTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciAdres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciTmlId = table.Column<long>(type: "bigint", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciAdres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciAdres_OgrenciTml_OgrenciTmlId",
                        column: x => x.OgrenciTmlId,
                        principalTable: "OgrenciTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciIletisim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciTmlId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciIletisim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciIletisim_OgrenciTml_OgrenciTmlId",
                        column: x => x.OgrenciTmlId,
                        principalTable: "OgrenciTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotTml",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciTmlId = table.Column<long>(type: "bigint", nullable: false),
                    DersId = table.Column<long>(type: "bigint", nullable: false),
                    NotKodTmlId = table.Column<long>(type: "bigint", nullable: false),
                    Deger = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotTml", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotTml_DersTml_DersId",
                        column: x => x.DersId,
                        principalTable: "DersTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotTml_NotKodTml_NotKodTmlId",
                        column: x => x.NotKodTmlId,
                        principalTable: "NotKodTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotTml_OgrenciTml_OgrenciTmlId",
                        column: x => x.OgrenciTmlId,
                        principalTable: "OgrenciTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciTmlId = table.Column<long>(type: "bigint", nullable: false),
                    DersId = table.Column<long>(type: "bigint", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciDers_DersTml_DersId",
                        column: x => x.DersId,
                        principalTable: "DersTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciDers_OgrenciTml_OgrenciTmlId",
                        column: x => x.OgrenciTmlId,
                        principalTable: "OgrenciTml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersTml_DersAlanKodId",
                table: "DersTml",
                column: "DersAlanKodId");

            migrationBuilder.CreateIndex(
                name: "IX_NotTml_DersId",
                table: "NotTml",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_NotTml_NotKodTmlId",
                table: "NotTml",
                column: "NotKodTmlId");

            migrationBuilder.CreateIndex(
                name: "IX_NotTml_OgrenciTmlId",
                table: "NotTml",
                column: "OgrenciTmlId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciAdres_OgrenciTmlId",
                table: "OgrenciAdres",
                column: "OgrenciTmlId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_DersId",
                table: "OgrenciDers",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_OgrenciTmlId",
                table: "OgrenciDers",
                column: "OgrenciTmlId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciIletisim_OgrenciTmlId",
                table: "OgrenciIletisim",
                column: "OgrenciTmlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotTml");

            migrationBuilder.DropTable(
                name: "OgrenciAdres");

            migrationBuilder.DropTable(
                name: "OgrenciDers");

            migrationBuilder.DropTable(
                name: "OgrenciIletisim");

            migrationBuilder.DropTable(
                name: "NotKodTml");

            migrationBuilder.DropTable(
                name: "DersTml");

            migrationBuilder.DropTable(
                name: "OgrenciTml");

            migrationBuilder.DropTable(
                name: "DersAlanKodTml");
        }
    }
}
