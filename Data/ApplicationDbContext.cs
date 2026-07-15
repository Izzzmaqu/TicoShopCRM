using Microsoft.EntityFrameworkCore;
using TicoShopCRM.Models;

namespace TicoShopCRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Campana> Campanas { get; set; }
        public DbSet<Caso> Casos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caso>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Casos)
                .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Empresa ABC S.A.", Email = "contacto@abc.com", Telefono = "2222-1111", Estado = "Activo", FechaRegistro = new DateTime(2026, 6, 1) },
                new Cliente { Id = 2, Nombre = "Comercial XYZ", Email = "ventas@xyz.com", Telefono = "8888-9999", Estado = "Activo", FechaRegistro = new DateTime(2026, 6, 10) }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Codigo = "PRD-001", Nombre = "Laptop Dell Inspiron 15", Categoria = "Electronica", PrecioUnitario = 449990, Stock = 12, Estado = "Activo" },
                new Producto { Id = 2, Codigo = "PRD-002", Nombre = "Mouse Logitech MX Master", Categoria = "Perifericos", PrecioUnitario = 32500, Stock = 34, Estado = "Activo" }
            );

            modelBuilder.Entity<Campana>().HasData(
                new Campana { Id = 1, Nombre = "Campaña Verano 2026", FechaInicio = new DateTime(2026, 6, 1), FechaFin = new DateTime(2026, 7, 31), Estado = "Activa", Presupuesto = 1500000 }
            );

            modelBuilder.Entity<Caso>().HasData(
                new Caso { Id = 1, ClienteId = 1, Titulo = "Problema con factura", Descripcion = "El cliente reporta inconsistencia en el monto facturado.", Estado = "Abierto", FechaCreacion = new DateTime(2026, 6, 20) }
            );
        }
    }
}