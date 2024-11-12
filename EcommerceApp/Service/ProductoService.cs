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

        /*
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.Include(p => p.Proveedor).ToListAsync();
        }
        */

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.Include(p => p.Proveedor).FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<Producto> UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        /*
        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
        */
        
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

        //crear un nuevo producto
        public async Task CreateProduct(Producto newProduct)
        {
            _context.Productos.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        //Actualizar un producto
        public async Task<bool> UpdateProduct(int id, Producto updatedProduct)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product == null) return false;

            product.Nombre = updatedProduct.Nombre;
            product.Precio = updatedProduct.Precio;
            // Actualiza otros campos según sea necesario

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
