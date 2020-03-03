using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Pedidos.Models;
using ConsoleApp1.Pedidos.Services;

namespace ConsoleApp1.Pedidos.Controllers
{
    public class DatosParsePedidosController : IDatosParsePedidosController
    {
        IDatosParsePedidosService datosParsePedidosService;

        public DatosParsePedidosController(IDatosParsePedidosService datosParsePedidosService)
        {
            this.datosParsePedidosService = datosParsePedidosService;
        }

        public List<Pedido> obtienePedidosArchivo(List<string[]> datos)
        {
            return datosParsePedidosService.datosToPedidos(datos);
        }
    }
}
