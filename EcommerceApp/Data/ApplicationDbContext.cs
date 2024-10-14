using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models; // Asegúrate de tener este namespace para el modelo Producto


namespace EcommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Agrega el DbSet para los productos
        public DbSet<Producto> Productos { get; set; }
    }
}
