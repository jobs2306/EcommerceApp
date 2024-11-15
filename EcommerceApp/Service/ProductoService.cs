using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Service
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            // Verificar que el ProveedorId exista en la base de datos
            var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == producto.ProveedorId);
            if (!proveedorExiste)
            {
                return null;  // Retorna null si el Proveedor no existe
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
        
        //obtener los productos solo para leer
        public async Task<IEnumerable<Producto>> GetAllProducts()
        {
            return await _context.Productos.ToListAsync();
        }

        //obtener un producto según el ID
        public async Task<Producto> GetProductById(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        //Actualizar un producto
        public async Task<bool> UpdateProduct(int id, Producto updatedProduct)
        {
            //se verifica que exista el producto
            var product = await _context.Productos.FindAsync(id);
            if (product == null) return false;

            //se verifica que exista el proveedor que se espera actualizar
            var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == updatedProduct.ProveedorId);
            if (!proveedorExiste) { return false; } 

            if(!string.IsNullOrEmpty(updatedProduct.Nombre)) product.Nombre = updatedProduct.Nombre;
            
            if(updatedProduct.Precio != null) product.Precio = updatedProduct.Precio;
            
            if(updatedProduct.Stock != null) product.Stock = updatedProduct.Stock;

            if(updatedProduct.ProveedorId != null && updatedProduct.ProveedorId != 0) product.ProveedorId = updatedProduct.ProveedorId;

            await _context.SaveChangesAsync();
            return true;
        }

        //Eliminar un producto
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product == null) return false;

            _context.Productos.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
