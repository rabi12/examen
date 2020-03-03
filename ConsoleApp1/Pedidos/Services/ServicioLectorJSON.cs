using ConsoleApp1.Pedidos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class ServicioLectorJSON
    {

        public string leerJSONConfig()
        {
            string path = "Config.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }
    }
}
