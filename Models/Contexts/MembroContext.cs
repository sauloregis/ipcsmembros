using ipcsmembros.Models.Entities;
using ipcsmembros.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ipcsmembros.Contexts
{

    public class MembroContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MembroContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Membro> Membros => Set<Membro>();
        public DbSet<Presbitero> Presbiteros => Set<Presbitero>();
        public DbSet<Diacono> Diaconos => Set<Diacono>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ipcsmembros"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MembroConfiguration());
            modelBuilder.ApplyConfiguration(new PresbiteroConfiguration());
        }
    }
}