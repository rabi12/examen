using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface IValidadorArchivoPedidosService
    {
         bool validarPlantillaPedidos(List<string []> datos);
    }
}
