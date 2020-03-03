using ConsoleApp1.Pedidos.Controllers;
using ConsoleApp1.Pedidos.Models;
using ConsoleApp1.Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Views
{
    class VistaPedidos
    {
        ILectorArchivoController lectorArchivoController;
        IDatosParsePedidosController datosParsePedidosController;
        SistemaGlobalPedidos sistemaGlobalPedidos;

        public void init()
        {
            //initSistemaGlobalPedidos();
            ServicioLectorJSON servicioLectorJson = new ServicioLectorJSON();
            this.sistemaGlobalPedidos = new SistemaGlobalPedidos(servicioLectorJson);
            ILectorArchivoService lectorArchivoService = new LectorArchivoService();
            IValidadorArchivoPedidosService validadorArchivoPedidosService = new ValidadorArchivoPedidosService();
            IDatosParsePedidosService datosParsePedidosService= new DatosParsePedidosService(validadorArchivoPedidosService);
     

            lectorArchivoController = new LectorArchivoController(lectorArchivoService);
            datosParsePedidosController = new DatosParsePedidosController(datosParsePedidosService);
            
        }
        
        private void initSistemaGlobalPedidos()
        {
            IMedioTransporte avion = new MedioTransporte("Avion",600,10);
            IMedioTransporte barco = new MedioTransporte("Barco", 46, 1);
            IMedioTransporte tren = new MedioTransporte("Tren", 80, 5);

            List<IMedioTransporte> listFedex = new List<IMedioTransporte>();
            listFedex.Add(barco);
            IPaqueteria paqueteriaFedex = new Paqueteria("Fedex", listFedex, 50);

            List<IMedioTransporte> listDHL = new List<IMedioTransporte>();
            listDHL.Add(avion);
            listDHL.Add(barco);
            IPaqueteria paqueteriaDHL = new Paqueteria("DHL", listDHL,40);

            List<IMedioTransporte> listEstafeta = new List<IMedioTransporte>();
            listEstafeta.Add(tren);
            listEstafeta.Add(barco);
            IPaqueteria paqueteriaEstafeta = new Paqueteria("Estafeta", listEstafeta, 20);

            List<IPaqueteria> paqueterias = new List<IPaqueteria>();
            paqueterias.Add(paqueteriaFedex);
            paqueterias.Add(paqueteriaDHL);
            paqueterias.Add(paqueteriaEstafeta);

            this.sistemaGlobalPedidos = new SistemaGlobalPedidos(paqueterias);

        }

        public string solicitaRuta()
        {
            //Console.WriteLine("Introduce la ruta completa del archivo");
            string ruta = "Archivo Pedidos.csv";//Convert.ToString(Console.ReadLine());

            return ruta;
        }

        public void muestraPedidosRuta(string ruta)
        {
            List<string> avisos=getMensajesPedidosArchivo(ruta);
            foreach(var aviso in avisos)
            {
                configurarColor(aviso);
                
                Console.WriteLine(aviso);
                Console.WriteLine("\n");
            }
        }

        private void configurarColor(string aviso)
        {
            if (aviso.Contains("llegará"))
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            if (aviso.Contains("no ofrece") || aviso.Contains("no se encuentra registrada"))
                Console.ForegroundColor = ConsoleColor.Red;

        }

        private List<string> getMensajesPedidosArchivo(string ruta)
        {
            try
            {
                List<string[]> datosArchivo = obtenerDatosArchivo(ruta);
                List<Pedido> pedidos = obtenerPedidosDatosArchivo(datosArchivo);

                return obtenerMensajesPedidos(pedidos);
            }
            catch (Exception e)
            {
                List<string> listaMensaje = new List<string>();
                listaMensaje.Add(e.Message);
                return listaMensaje;
            }
        }

        private List<string []> obtenerDatosArchivo(string ruta)
        {
            return this.lectorArchivoController.obtenerDatosArchivo(ruta);
        }

        private List<Pedido> obtenerPedidosDatosArchivo(List<string[]> datosArchivo)
        {
            return this.datosParsePedidosController.obtienePedidosArchivo(datosArchivo);
        }

        private List<string> obtenerMensajesPedidos(List<Pedido> pedidos)
        {
            //return this.pedidoController.obtenerMensajesPedidos(pedidos);
            List<string> list = new List<string>();
            foreach (Pedido pedido in pedidos)
            {
                list.Add(this.sistemaGlobalPedidos.solicitarPedido(pedido));
            }

            return list;
        }
    }
}
