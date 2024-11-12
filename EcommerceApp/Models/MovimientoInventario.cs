namespace EcommerceApp.Models
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsEntrada { get; set; }

        public Producto Producto { get; set; }
    }
}
