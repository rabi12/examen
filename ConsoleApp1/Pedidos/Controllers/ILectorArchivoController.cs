using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Controllers
{
    public interface ILectorArchivoController
    {
        List<string[]> obtenerDatosArchivo(string ruta);
    }
}
