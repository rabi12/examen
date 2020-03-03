using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public interface IMedioTransporte
    {

         string getMedio();

         decimal getCostoPorKilometro();

         decimal getVelocidad();

         decimal getTiempoTraslado(decimal distancia);
    }
}
