using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Models;
using EcommerceApp.Service;
using EcommerceApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProveedores()
        {
            var proveedores = await _proveedorService.GetAllProveedores();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProveedorById(int id)
        {
            var proveedor = await _proveedorService.GetProveedorById(id);
            if(proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProveedor([FromBody] Proveedor newProveedor)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ProveedorCreado = await _proveedorService.AddAsync(newProveedor);

            return CreatedAtAction(nameof(GetProveedorById), new { id = newProveedor.Id }, newProveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, [FromBody] Proveedor updateProv)
        {
            var result = await _proveedorService.UpdateProveedor(id, updateProv);
            if(!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            bool ProdInProv = _proveedorService.VerifyProdInProveedor(id);

            if(ProdInProv)
            {
                return BadRequest( new { error = "El proveedor tiene productos asignados."});
            }

            var result = await _proveedorService.DeleteProveedor(id);

            if (!result)
            {
                return NotFound(new { error = "El proveedor especificado no existe."});
            }

            return NoContent();
        }

        
        //test para probar que se pueda acceder --funciona
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var proveedores = await _proveedorService.GetAllProveedores();
            return Ok(proveedores);
        }

    }
}
