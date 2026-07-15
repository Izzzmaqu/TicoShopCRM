using Microsoft.EntityFrameworkCore;
using TicoShopCRM.Models;

namespace TicoShopCRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Campana> Campanas { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Promocion> Promociones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed de datos inicial (opcional, útil para InMemory)
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Empresa ABC S.A.", Email = "contacto@abc.com", Estado = "Activo" }
            );
        }
    }
}