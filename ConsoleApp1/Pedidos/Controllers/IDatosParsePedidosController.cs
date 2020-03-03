using ConsoleApp1.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Controllers
{
    public interface IDatosParsePedidosController
    {
        List<Pedido> obtienePedidosArchivo(List<string[]> datos);
    }
}
