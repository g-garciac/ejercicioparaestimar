using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidosWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly PedidoVm PedidoModel = new() { Productos = new List<ProductoPedidoVm>() };

        private static readonly IEnumerable<Producto> Catalogo =
            Enumerable.Range(0, 1_000)
            .Select(i =>
                new Producto { Id = $"{i:D3}", Nombre = $" Producto {i}", Precio = new decimal(i) })
            .ToArray();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(PedidoModel);
        }

        [HttpPost]
        public IActionResult Buscar(PedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), PedidoModel);
            }
            var existe = PedidoModel.Productos.FirstOrDefault(p => p.Id.Equals(model.CodigoABuscar));
            if (existe is null)
            {
                var encontrado = Catalogo.FirstOrDefault(p => p.Id.Equals(model.CodigoABuscar));
                if (encontrado is null)
                {
                    ModelState.AddModelError(nameof(PedidoVm.CodigoABuscar), $"No existe el código indicado: {model.CodigoABuscar}");
                    return View(nameof(Index), PedidoModel);
                }
                PedidoModel.Productos.Add(new ProductoPedidoVm
                {
                    Id = encontrado.Id,
                    Nombre = encontrado.Nombre,
                    Precio = encontrado.Precio,
                    Cantidad = model.CantidadAgregar,
                }
                );
            }
            else
                existe.Cantidad += model.CantidadAgregar;
            return View(nameof(Index), PedidoModel);
        }
    }
}
