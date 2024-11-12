using EcommerceApp.Models;

namespace EcommerceApp.Service.Interface
{
    public interface IProveedorService
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task<Proveedor> GetByIdAsync(int id);
        Task<Proveedor> AddAsync(Proveedor proveedor);
        Task<Proveedor> UpdateAsync(Proveedor proveedor);
        Task DeleteAsync(int id);
    }
}
