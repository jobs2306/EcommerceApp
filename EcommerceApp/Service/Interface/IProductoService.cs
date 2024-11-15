using EcommerceApp.Models;

namespace EcommerceApp.Service.Interface
{
    public interface IProductoService
    {
        //Agrear producto
        Task<Producto> AddAsync(Producto producto);
        //Obtener todos los productos
        Task<IEnumerable<Producto>> GetAllProducts();
        //Obtener todos los productos por Id
        Task<Producto> GetProductById(int id);
        //Actualizar un producto
        Task<bool> UpdateProduct(int id, Producto updatedProduct);
        //Borrar un producto
        Task<bool> DeleteProduct(int id);
    }
}
