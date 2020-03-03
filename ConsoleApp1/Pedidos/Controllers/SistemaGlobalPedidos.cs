using ConsoleApp1.Pedidos.Controllers;
using ConsoleApp1.Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public class SistemaGlobalPedidos
    {
        private List<IPaqueteria> paqueterias;
        public Func<DateTime> fechaActual { get; set; }

        public SistemaGlobalPedidos(ServicioLectorJSON servicio)
        {
            this.fechaActual = () => DateTime.Now;
            this.paqueterias = inicializarConfiguracionJSON(servicio);
        }

        public List<IPaqueteria> inicializarConfiguracionJSON(ServicioLectorJSON servicio)
        {
            InterfaceAdapterJSON lectorJSON = new AdapterJSON(servicio);
            return lectorJSON.getPaqueterias();
        }


        public SistemaGlobalPedidos(List<IPaqueteria> paqueterias)
        {
            this.fechaActual = () => DateTime.Now;
            this.paqueterias = paqueterias;
        }

        public string solicitarPedido(Pedido pedido)
        {
            /*
             * Tu paquete [Expresión1] de [Origen] y [Expresión2] a [Destino] [Expresión3] [Rango de Tiempo] y [Expresión4] un costo de [Costo de envío] (Cualquier reclamación con [Paquetería]).
             * Tu paquete salió de Ticul y llegó a Motul hace 1 hora y tuvo un costo de $480 (cualquier reclamación con Estafeta).
             * */
            string mensaje = "";
            
            
            try
            {
                pedido = completarInformacionPedido(pedido);
                mensaje = "Tu paquete " + obtenerExpresionTiempo(pedido) + " de " + pedido.origen + " y " + obtenerExpresionLlegada(pedido) + " a " + pedido.destino + " " +
                obtenerTiempoLlegada(pedido) + " " + obtenerRangoTiempo(pedido) + " y " + obtenerExpresionTiempoCosto(pedido) + " un costo de " + pedido.costoEnvio + "(Cualquier reclamación con " + pedido.paqueteria + ")";
                mensaje += investigarMejorPrecio(pedido); 
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }                 

            return mensaje;
        }

        private string investigarMejorPrecio(Pedido pedido)
        {
            string mensaje = "";

            foreach (IPaqueteria paqueteria in this.paqueterias)
            {
                if (!paqueteria.getNombre().Equals(pedido.paqueteria))
                {
                    IMedioTransporte medio = paqueteria.getMedioTransporte(pedido.medioTransporte);
                    if (medio != null)
                    {
                        decimal precio= (medio.getCostoPorKilometro() * pedido.distancia) * (1 + (paqueteria.getUtilidad() / 100));
                        if (pedido.costoEnvio > precio)
                        {
                            mensaje = "\n" + "Si hubieras pedido en " + paqueteria.getNombre() + " te hubiera costado $" + (pedido.costoEnvio - precio) + " más barato.";
                        }
                    }
                }
            }

            return mensaje;
        }


        private Pedido completarInformacionPedido(Pedido pedido)
        {
            pedido.tiempoTraslado = obtenerTiempoTraslado(pedido);
            pedido.fechaEntrega = pedido.fechaPedido.AddHours(Double.Parse(pedido.tiempoTraslado.ToString()));
            pedido.costoEnvio = getCostoEnvio(pedido);

            return pedido;
         }

        private decimal obtenerTiempoTraslado(Pedido pedido)
        {
            foreach (IPaqueteria paqueteria in this.paqueterias) {
                if (paqueteria.getNombre().Equals(pedido.paqueteria))
                {
                    IMedioTransporte medio = paqueteria.getMedioTransporte(pedido.medioTransporte);
                    if(medio!=null)
                        return medio.getTiempoTraslado(pedido.distancia);
                    else
                        break;
                }
            }
            return 0.0M;
        }

        private string obtenerExpresionTiempo(Pedido pedido)
        {
            if(pedido.fechaEntrega < this.fechaActual())
                return "salió";
            return "ha salido";
        }

        private string obtenerExpresionLlegada(Pedido pedido)
        {
            if (pedido.fechaEntrega < this.fechaActual())
                return "llegó";
            return "llegará";
        }

        private string obtenerTiempoLlegada(Pedido pedido)
        {
            if (pedido.fechaEntrega < this.fechaActual())
                return "hace";
            return "dentro de";
        }

        private string obtenerExpresionTiempoCosto(Pedido pedido)
        {
            if (pedido.fechaEntrega < this.fechaActual())
                return "tuvó";
            return "tendrá";
        }

      
        /*(Costo por km del [Medio de Transporte] * [Distancia]) * (1 + Margen de utilidad de la [Paquetería]/100)*/
        public decimal getCostoEnvio(Pedido pedido)
        {
            foreach (IPaqueteria paqueteria in this.paqueterias)
            {
                if (paqueteria.getNombre().Equals(pedido.paqueteria))
                {
                    IMedioTransporte medio = paqueteria.getMedioTransporte(pedido.medioTransporte);
                    if (medio != null)
                    {
                        return (medio.getCostoPorKilometro() * pedido.distancia) * (1 + (paqueteria.getUtilidad() / 100));
                    }
                    else
                    {
                        throw new Exception(paqueteria.getNombre() +" no ofrece el servicio de transporte "+pedido.medioTransporte+", te recomendamos cotizar en otra empresa.");
                    }
                }
            }

            throw new Exception("La Paquetería: " + pedido.paqueteria+" no se encuentra registrada en nuestra red de distribución.");

            return 0;
        }

        public string obtenerRangoTiempo(Pedido pedido)
        {
            
            DiferenciaFechasController controllerFechas = new DiferenciaFechasController(new CalculadorDiferenciaFechasEnMeses(), new CalculadorDiferenciaFechasEnDias(),
                new CalculadorDiferenciaFechasEnHoras(), new CalculadorDiferenciaFechasEnMinutos());

            return controllerFechas.obtenerRangoTiempo(pedido.fechaEntrega, this.fechaActual());

        }

    }
}
