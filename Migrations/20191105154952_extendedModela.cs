using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesAdaro.API.Migrations
{
    public partial class extendedModela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nip = table.Column<string>(nullable: true),
                    NamaDosen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mahasiswa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nim = table.Column<string>(nullable: true),
                    NamaMhs = table.Column<string>(nullable: true),
                    TglLahir = table.Column<DateTime>(nullable: false),
                    Alamat = table.Column<string>(nullable: true),
                    JenisKelamin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MataKuliah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kodeMK = table.Column<string>(nullable: true),
                    NamaMK = table.Column<string>(nullable: true),
                    Sks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataKuliah", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perkuliahans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nilai = table.Column<char>(nullable: false),
                    DosenId = table.Column<int>(nullable: false),
                    MahasiswaId = table.Column<int>(nullable: false),
                    MataKuliahId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perkuliahans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perkuliahans_Dosen_DosenId",
                        column: x => x.DosenId,
                        principalTable: "Dosen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahans_Mahasiswa_MahasiswaId",
                        column: x => x.MahasiswaId,
                        principalTable: "Mahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahans_MataKuliah_MataKuliahId",
                        column: x => x.MataKuliahId,
                        principalTable: "MataKuliah",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahans_DosenId",
                table: "Perkuliahans",
                column: "DosenId");

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahans_MahasiswaId",
                table: "Perkuliahans",
                column: "MahasiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perkuliahans_MataKuliahId",
                table: "Perkuliahans",
                column: "MataKuliahId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perkuliahans");

            migrationBuilder.DropTable(
                name: "Dosen");

            migrationBuilder.DropTable(
                name: "Mahasiswa");

            migrationBuilder.DropTable(
                name: "MataKuliah");
        }
    }
}
