using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesAdaro.API.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dosens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nip = table.Column<string>(nullable: true),
                    NamaDosen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mahasiswas",
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
                    table.PrimaryKey("PK_Mahasiswas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MataKuliahs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KodeMK = table.Column<string>(nullable: true),
                    NamaMK = table.Column<string>(nullable: true),
                    Sks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataKuliahs", x => x.Id);
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
                        name: "FK_Perkuliahans_Dosens_DosenId",
                        column: x => x.DosenId,
                        principalTable: "Dosens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahans_Mahasiswas_MahasiswaId",
                        column: x => x.MahasiswaId,
                        principalTable: "Mahasiswas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perkuliahans_MataKuliahs_MataKuliahId",
                        column: x => x.MataKuliahId,
                        principalTable: "MataKuliahs",
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
                name: "Dosens");

            migrationBuilder.DropTable(
                name: "Mahasiswas");

            migrationBuilder.DropTable(
                name: "MataKuliahs");
        }
    }
}
