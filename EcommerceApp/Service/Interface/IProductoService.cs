using EcommerceApp.Models;

namespace EcommerceApp.Service.Interface
{
    public interface IProductoService
    {
       // Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<Producto> AddAsync(Producto producto);
        Task<Producto> UpdateAsync(Producto producto);
        //Task DeleteAsync(int id);

        //Nuevas funciones para mejor desempeño
        Task<IEnumerable<Producto>> GetAllProducts();
        Task<Producto> GetProductById(int id);
        Task CreateProduct(Producto newProduct);
        Task<bool> UpdateProduct(int id, Producto updatedProduct);
        Task<bool> DeleteProduct(int id);
    }
}
