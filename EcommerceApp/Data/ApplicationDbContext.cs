using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models; 


namespace EcommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Agrega el DbSet para los datos que se quieren manipular
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()

                //.HasOne(p => p.Proveedor)

                .HasOne<Proveedor>()
                .WithMany()  // Suponiendo que Proveedor tiene una colección de Productos
              //  .HasForeignKey(p => p.ProveedorId) 
                .OnDelete(DeleteBehavior.Restrict);  // Evita eliminar un proveedor con productos asociados
        }
        */
    }
}
