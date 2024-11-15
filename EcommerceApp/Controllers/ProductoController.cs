using EcommerceApp.Models;
using EcommerceApp.Service;
using EcommerceApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers

{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productos = await _productoService.GetAllProducts();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var producto = await _productoService.GetProductById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Producto newProduct)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Esto devolverá un error 400 si falta algún dato
            }

            // Llama al servicio para crear el producto y verifica si el ProveedorId es válido
            var productoCreado = await _productoService.AddAsync(newProduct);
            if (productoCreado == null)
            {
                return BadRequest(new { error = "El ProveedorId especificado no existe o no lo indicó." });
            }

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Producto updatedProduct)
        {
            var result = await _productoService.UpdateProduct(id, updatedProduct);
            if (!result)
            {
                return BadRequest(new {error = "El producto no fue encontrado o el Proveedor no existe."});
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productoService.DeleteProduct(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var productos = await _productoService.GetAllProducts();
            return Ok(productos);
        }

    }
}
