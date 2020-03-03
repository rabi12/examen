using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public class Pedido
    {
        public string origen;
        public string destino;
        public decimal distancia;
        public string paqueteria;
        public string medioTransporte;
        public DateTime fechaPedido;

        public decimal tiempoTraslado;
        public DateTime fechaEntrega;
        public decimal costoEnvio;

        

        public Pedido(string origen, string destino, decimal distancia, string paqueteria,string medioTransporte, DateTime fechaPedido)
        {
            this.origen = origen;
            this.destino = destino;
            this.distancia = distancia;
            this.paqueteria = paqueteria;
            this.medioTransporte = medioTransporte;
            this.fechaPedido = fechaPedido;
        }

        public string toString()
        {
            return origen + "," + destino + "," + distancia + "," + paqueteria + "," + medioTransporte + "," + fechaPedido;
        }

    }
}
