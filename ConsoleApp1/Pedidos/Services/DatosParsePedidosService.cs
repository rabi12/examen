using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Pedidos.Models;

namespace ConsoleApp1.Pedidos.Services
{
    public class DatosParsePedidosService : IDatosParsePedidosService
    {
        private IValidadorArchivoPedidosService validador;

        public DatosParsePedidosService(IValidadorArchivoPedidosService validador)
        {
            this.validador = validador;
        }

        public List<Pedido> datosToPedidos(List<string[]> datos)
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (!validador.validarPlantillaPedidos(datos))
            {
                throw new Exception("El archivo tiene formato incorrecto");
            }
            else
            {
               foreach(var dato in datos)
                {
                    try { 
                        Pedido newPedido = new Pedido(dato[0], dato[1], Int32.Parse(dato[2]), dato[3], dato[4], DateTime.Parse(dato[5]));
                        pedidos.Add(newPedido);
                    }
                    catch(Exception e)
                    {
                        throw new Exception("El pedido "+ dato[0] +"-"+ dato[1]+ " tiene formato incorrecto.");
                    }
                }
            }
            return pedidos;
        }
    }
}
