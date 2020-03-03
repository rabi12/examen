using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class ValidadorArchivoPedidosService : IValidadorArchivoPedidosService
    {
        public bool validarPlantillaPedidos(List<string[]> datos)
        {
            if (datos == null)
                throw new Exception("El archivo no tiene el formato correcto o esta vacío");

            foreach(var dato in datos)
            {
                if (dato.Length != 6 || string.IsNullOrEmpty(dato[0]) || string.IsNullOrEmpty(dato[1])
                    || string.IsNullOrEmpty(dato[2]) || string.IsNullOrEmpty(dato[3]) 
                    || string.IsNullOrEmpty(dato[4]) || string.IsNullOrEmpty(dato[5]))
                    return false;
            }

            return true;
        }
    }
}
