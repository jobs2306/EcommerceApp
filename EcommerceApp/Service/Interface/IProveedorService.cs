using EcommerceApp.Models;

namespace EcommerceApp.Service.Interface
{
    public interface IProveedorService
    {
        //Agregar proveedor
        Task<Proveedor> AddAsync(Proveedor proveedor);
        //Obtener proveedor
        Task<IEnumerable<Proveedor>> GetAllProveedores();
        //Obtener proveedor según Id
        Task<Proveedor> GetProveedorById(int id);
        //Actualizar proveedor 
        Task<bool> UpdateProveedor(int id, Proveedor UpdatedProveedor);
        //Borrar proveedor
        Task<bool> DeleteProveedor(int id);
        //verificar si un proveedor tiene productos asignados
        bool VerifyProdInProveedor(int id);
    }
}
