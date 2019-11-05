using Microsoft.EntityFrameworkCore;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Perkuliahan> Perkuliahans {get; set;}
    }
}