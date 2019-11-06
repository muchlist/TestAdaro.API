﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesAdaro.API.Data;

namespace TesAdaro.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191106053454_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TesAdaro.API.Models.Dosen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NamaDosen");

                    b.Property<string>("Nip");

                    b.HasKey("Id");

                    b.ToTable("Dosens");
                });

            modelBuilder.Entity("TesAdaro.API.Models.Mahasiswa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alamat");

                    b.Property<string>("JenisKelamin");

                    b.Property<string>("NamaMhs");

                    b.Property<string>("Nim");

                    b.Property<DateTime>("TglLahir");

                    b.HasKey("Id");

                    b.ToTable("Mahasiswas");
                });

            modelBuilder.Entity("TesAdaro.API.Models.MataKuliah", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KodeMK");

                    b.Property<string>("NamaMK");

                    b.Property<int>("Sks");

                    b.HasKey("Id");

                    b.ToTable("MataKuliahs");
                });

            modelBuilder.Entity("TesAdaro.API.Models.Perkuliahan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DosenId");

                    b.Property<int>("MahasiswaId");

                    b.Property<int>("MataKuliahId");

                    b.Property<string>("Nilai");

                    b.HasKey("Id");

                    b.HasIndex("DosenId");

                    b.HasIndex("MahasiswaId");

                    b.HasIndex("MataKuliahId");

                    b.ToTable("Perkuliahans");
                });

            modelBuilder.Entity("TesAdaro.API.Models.Perkuliahan", b =>
                {
                    b.HasOne("TesAdaro.API.Models.Dosen", "Dosen")
                        .WithMany("Perkuliahans")
                        .HasForeignKey("DosenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TesAdaro.API.Models.Mahasiswa", "Mahasiswa")
                        .WithMany("Perkuliahans")
                        .HasForeignKey("MahasiswaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TesAdaro.API.Models.MataKuliah", "MataKuliah")
                        .WithMany("Perkuliahans")
                        .HasForeignKey("MataKuliahId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}