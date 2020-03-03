using ConsoleApp1.Pedidos.Controllers;
using ConsoleApp1.Pedidos.Models;
using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Pedidos.Controllers
{
    [TestClass]
    public class DatosParseEventosControllerUTest
    {
        [TestMethod]
        public void obtieneEventosArchivo_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Merida", "Tizimin", "200", "MercadoLibre", "Avion", "23 - 03 - 2020 12:00:00","Pedido mas datos" });

            DatosParsePedidosService service = new DatosParsePedidosService(new ValidadorArchivoPedidosService());
            var SUT = new DatosParsePedidosController(service);

            // Act
            try
            {
                var resultado = SUT.obtienePedidosArchivo(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void obtieneEventosArchivo_FormatoIncorrectoMenosDatos_Exception()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Pedido menos datos", "Tizimin", "200", "MercadoLibre", "Avion" });

            DatosParsePedidosService service = new DatosParsePedidosService(new ValidadorArchivoPedidosService());
            var SUT = new DatosParsePedidosController(service);

            // Act
            try
            {
                var resultado = SUT.obtienePedidosArchivo(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void obtieneEventosArchivo_FormatoCorrecto_Evento()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Merida", "Tizimin", "200", "DHL", "Avion", "23 - 03 - 2020 12:00:00" });

            DatosParsePedidosService service = new DatosParsePedidosService(new ValidadorArchivoPedidosService());
            var SUT = new DatosParsePedidosController(service);

            // Act
            var resultado = SUT.obtienePedidosArchivo(datos);
            
            // Assert
            Assert.IsInstanceOfType(resultado[0], typeof(Pedido));
        }

        [TestMethod]
        public void obtieneEventosArchivo_Null_Excpetion()
        {
            //Arrange
            List<string[]> datos = null;

            DatosParsePedidosService service = new DatosParsePedidosService(new ValidadorArchivoPedidosService());
            var SUT = new DatosParsePedidosController(service);

            // Act
            try
            {
                var resultado = SUT.obtienePedidosArchivo(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo no tiene el formato correcto o esta vacío");
                return;
            }

            Assert.Fail("No se lanzo ninguna excepcion.");
        }
    }
}
