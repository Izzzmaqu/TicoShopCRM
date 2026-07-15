using TicoShopCRM.Models;

namespace TicoShopCRM.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Clientes.Any() || context.Productos.Any() || context.Campanas.Any() || context.Casos.Any())
            {
                return;
            }

            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nombre = "Juan Pérez",
                    Email = "juan@correo.com",
                    Telefono = "8888-1111",
                    FechaRegistro = DateTime.Now.AddDays(-20),
                    Estado = "Activo"
                },
                new Cliente
                {
                    Nombre = "María López",
                    Email = "maria@correo.com",
                    Telefono = "8888-2222",
                    FechaRegistro = DateTime.Now.AddDays(-10),
                    Estado = "Activo"
                }
            };

            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            var productos = new List<Producto>
            {
                new Producto
                {
                    Codigo = "P001",
                    Nombre = "Laptop Dell",
                    Categoria = "Tecnología",
                    PrecioUnitario = 450000,
                    Stock = 5,
                    Estado = "Activo"
                },
                new Producto
                {
                    Codigo = "P002",
                    Nombre = "Mouse Logitech",
                    Categoria = "Accesorios",
                    PrecioUnitario = 15000,
                    Stock = 20,
                    Estado = "Activo"
                }
            };

            context.Productos.AddRange(productos);

            var campanas = new List<Campana>
            {
                new Campana
                {
                    Nombre = "Promo Mitad de Año",
                    FechaInicio = DateTime.Now.AddDays(-15),
                    FechaFin = DateTime.Now.AddDays(15),
                    Estado = "Activa",
                    Presupuesto = 250000
                },
                new Campana
                {
                    Nombre = "Campaña Back to School",
                    FechaInicio = DateTime.Now.AddDays(5),
                    FechaFin = DateTime.Now.AddDays(40),
                    Estado = "Pausada",
                    Presupuesto = 400000
                }
            };

            context.Campanas.AddRange(campanas);
            context.SaveChanges();

            var casos = new List<Caso>
            {
                new Caso
                {
                    ClienteId = clientes[0].Id,
                    Titulo = "Consulta por garantía",
                    Descripcion = "El cliente solicita información sobre garantía del producto comprado.",
                    Estado = "Abierto",
                    FechaCreacion = DateTime.Now.AddDays(-3)
                },
                new Caso
                {
                    ClienteId = clientes[1].Id,
                    Titulo = "Problema con entrega",
                    Descripcion = "La entrega no llegó en la fecha indicada.",
                    Estado = "EnProceso",
                    FechaCreacion = DateTime.Now.AddDays(-1)
                }
            };

            context.Casos.AddRange(casos);
            context.SaveChanges();
        }
    }
}