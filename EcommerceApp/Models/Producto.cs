using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace EcommerceApp.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string? Codigo { get; set; } 
        public decimal? Precio { get; set; } 
        public int? Stock { get; set; }

        public int ProveedorId { get; set; }

        public Proveedor? Proveedor { get; set; } 
    }
}
