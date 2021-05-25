using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PedidosWebApp.Models
{
    public class PedidoVm
    {
        [Required(ErrorMessage = "El código a buscar es requerido")]
        [Display(Name = "Código")]
        public string CodigoABuscar { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0.5, 10_000, ErrorMessage = "La cantidad debe ser entre 0.5 y 10,000")]
        public decimal CantidadAgregar { get; set; }
        public IList<ProductoPedidoVm> Productos { get; set; }

        [Display(Name = "Total")]
        public decimal Total => Productos is null ? 0 : Productos.Sum(p => p.Importe);
    }
}
