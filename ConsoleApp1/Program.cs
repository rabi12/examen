using ConsoleApp1.Pedidos.Views;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
   
    class Program
    {
        static void Main(string[] args)
        {
            VistaPedidos vista = new VistaPedidos();
            vista.init();

            string ruta = vista.solicitaRuta();

            vista.muestraPedidosRuta(ruta);
    
            Console.ReadKey();
        }

    }

}
