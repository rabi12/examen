using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class LectorArchivoService : ILectorArchivoService
    {
        public List<string[]> leerArchivo(string ruta)
        {
            
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(ruta))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }
    }
}
