using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public class MedioTransporte:IMedioTransporte
    {
        private decimal costoPorKilometro;
        private decimal velocidad;
        private string medio;
        
        public MedioTransporte(string medio, decimal velocidad, decimal costoPorKilometro)
        {
            this.medio = medio;
            this.velocidad = velocidad;
            this.costoPorKilometro = costoPorKilometro;
        }

        public decimal getCostoPorKilometro()
        {
            return this.costoPorKilometro;
        }

        public string getMedio()
        {
            return this.medio;
        }

        public decimal getVelocidad()
        {
            return this.velocidad;
        }

        public decimal getTiempoTraslado(decimal distanciaKm)
        {
            return distanciaKm / velocidad;
        }

    }
}
