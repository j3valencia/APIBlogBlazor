using ApiBlog.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Agregar MOdelos
        public DbSet<Entrada> Entradas { get; set; }

    }
}
