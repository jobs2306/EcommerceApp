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

        public async Task<Proveedor> AddAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task<IEnumerable<Proveedor>> GetAllProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> GetProveedorById(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<bool> UpdateProveedor(int id, Proveedor UpdateProveedor)
        {
            var prov = await _context.Proveedores.FindAsync(id);
            if (prov == null) return false;

            if(!string.IsNullOrEmpty(UpdateProveedor.Nombre)) prov.Nombre = UpdateProveedor.Nombre;
            
            if(!string.IsNullOrEmpty(UpdateProveedor.Telefono)) prov.Telefono = UpdateProveedor.Telefono;
            
            if(!string.IsNullOrEmpty(UpdateProveedor.Direccion)) prov.Direccion = UpdateProveedor.Direccion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProveedor(int id)
        {   
            var prov = await _context.Proveedores.FindAsync(id);

            if (prov == null) return false;

            _context.Proveedores.Remove(prov);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool VerifyProdInProveedor(int id)
        {
            bool tieneProductosAsociados = _context.Productos.Any(p => p.ProveedorId == id);

            if (tieneProductosAsociados)
            {
                return true;
            }

            return false;
        }
    }
}
