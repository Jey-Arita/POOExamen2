using Examen2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Examen2.Database
{
    public class ExamenContext : DbContext
    {
        internal readonly object Amortizaciones;

        public ExamenContext(DbContextOptions options)
                : base(options)
        {
            
        }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<PrestamoEntity> Prestamos { get; set; }
        public DbSet<InfoPrestamoEntity> InfoPrestamos { get; set; }
    }
}
