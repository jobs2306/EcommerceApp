using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Service
{
    public class ProveedorService : IProveedorService
    {
        private readonly ApplicationDbContext _context;

        public ProveedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<Proveedor> AddAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task<Proveedor> UpdateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
