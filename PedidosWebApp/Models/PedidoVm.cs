using System.Collections.Generic;
using System.Linq;

namespace PedidosWebApp.Models
{
    public class PedidoVm
    {
        public string CodigoABuscar { get; set; }
        public decimal CantidadAgregar { get; set; }
        public IEnumerable<ProductoPedidoVm> Productos { get; set; }
        public decimal Total => Productos.Sum(p => p.Importe);
    }
}
