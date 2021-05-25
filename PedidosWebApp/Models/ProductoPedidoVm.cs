namespace PedidosWebApp.Models
{
    public class ProductoPedidoVm
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe => Cantidad * Precio;
    }
}
