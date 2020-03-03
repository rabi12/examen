using ConsoleApp1.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface IDatosParsePedidosService
    {
         List<Pedido> datosToPedidos(List<string[]> datos);
    }
}
