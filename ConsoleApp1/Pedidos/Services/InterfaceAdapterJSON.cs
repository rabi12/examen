using ConsoleApp1.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface InterfaceAdapterJSON
    {
        List<IMedioTransporte> getMediosTransporte();
        List<IPaqueteria> getPaqueterias();
    }
}
