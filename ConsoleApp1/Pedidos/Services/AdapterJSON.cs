using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Pedidos.Models;
using Newtonsoft.Json;

namespace ConsoleApp1.Pedidos.Services
{
    public class AdapterJSON : InterfaceAdapterJSON
    {
        private ServicioLectorJSON servicio;

        public AdapterJSON(ServicioLectorJSON servicio)
        {
            this.servicio = servicio;
        }

        public List<IMedioTransporte> getMediosTransporte()
        {
            string informacion = servicio.leerJSONConfig();
            List<InfoConfiguracionDTO> informacionDTO= JsonConvert.DeserializeObject<List<InfoConfiguracionDTO>>(informacion);

            List<IMedioTransporte> mediosTransporte = new List<IMedioTransporte>();
            
            foreach (MedioTransporte medio in informacionDTO[0].MediosTransporte)
            {
                mediosTransporte.Add(medio);
            }
             
            return mediosTransporte;
        }

        public List<IPaqueteria> getPaqueterias()
        {
            string informacion = servicio.leerJSONConfig();
            List<InfoConfiguracionDTO> informacionDTO = JsonConvert.DeserializeObject<List<InfoConfiguracionDTO>>(informacion);

            List<IMedioTransporte> mediosTransporte = new List<IMedioTransporte>();
            List<IPaqueteria> paqueterias = new List<IPaqueteria>();
            foreach (MedioTransporte medio in informacionDTO[0].MediosTransporte)
            {
                mediosTransporte.Add(medio);
            }

            foreach (PaqueteriaDTO paqueteriaDTO in informacionDTO[1].Paqueterias)
            {
                string nombrePaqueteria = paqueteriaDTO.paqueteria;
                List<IMedioTransporte> transportePaqueteria = new List<IMedioTransporte>();
                foreach (MedioTransporte medio in mediosTransporte)
                {
                    foreach (MedioDTO medioDTO in paqueteriaDTO.medios)
                    {
                        if (medioDTO.medio.Equals(medio.getMedio()))
                        {
                            transportePaqueteria.Add(medio);
                            break;
                        }
                            
                    }
                }

                IPaqueteria paqueteria = new Paqueteria(nombrePaqueteria,transportePaqueteria,Decimal.Parse(paqueteriaDTO.margenUtilidad.ToString()));
                paqueterias.Add(paqueteria);
            }

            return paqueterias;
        }
    }
}
