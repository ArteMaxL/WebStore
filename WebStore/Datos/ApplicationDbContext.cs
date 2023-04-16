using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoAplicacion> TipoAplicaciones { get; set; }
    }
}
