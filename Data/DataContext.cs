using Microsoft.EntityFrameworkCore;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Dosen> Dosens {get; set;}
        public DbSet<Mahasiswa> Mahasiswas {get; set;}
        public DbSet<MataKuliah> MataKuliahs {get; set;}
        public DbSet<Perkuliahan> Perkuliahans {get; set;}
    }
}