using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public interface IPaqueteria
    {
         string getNombre();

         List<IMedioTransporte> getMediosTransporte();

        decimal getUtilidad();

        bool tienesMedioTransporte(string nombre);

         IMedioTransporte getMedioTransporte(string nombre);

    }
}
