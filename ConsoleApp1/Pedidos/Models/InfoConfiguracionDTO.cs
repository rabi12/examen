using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public class MedioDTO
    {
        public string medio { get; set; }
    }

    public class PaqueteriaDTO
    {
        public string paqueteria { get; set; }
        public double margenUtilidad { get; set; }
        public List<MedioDTO> medios { get; set; }
    }

    public class InfoConfiguracionDTO
    {
       public List<MedioTransporte> MediosTransporte { get; set; }
       public List<PaqueteriaDTO> Paqueterias { get; set; }
        
    }
}
