using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface ILectorArchivoService
    {
         List<string[]> leerArchivo(string ruta);
    }
}
