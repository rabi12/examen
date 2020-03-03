using ConsoleApp1.Pedidos.Models;
using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class DatosParseEventosServiceUTest
    {
        [TestMethod]
        public void datosToEventos_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Merida", "Tizimin", "200", "MercadoLibre", "Avion", "23 - 03 - 2020 12:00:00", "Pedido mas datos" });

            var SUT = new DatosParsePedidosService(new ValidadorArchivoPedidosService());

            // Act
            try
            {
                var resultado = SUT.datosToPedidos(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void datosToEventos_FormatoIncorrectoMenosDatos_Exception()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Merida", "Tizimin", "200", "MercadoLibre", "Avion" });
            var SUT = new DatosParsePedidosService(new ValidadorArchivoPedidosService());

            // Act
            try
            {
                var resultado = SUT.datosToPedidos(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void datosToEventos_FormatoCorrecto_Evento()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] {"Merida","Tizimin","200","DHL","Barco","23-01-2020 12:00:00" });

            var SUT = new DatosParsePedidosService(new ValidadorArchivoPedidosService());

            // Act
            var resultado = SUT.datosToPedidos(datos);

            // Assert
            Assert.IsInstanceOfType(resultado[0], typeof(Pedido));
        }

        [TestMethod]
        public void datosToEventos_Null_Excpetion()
        {
            //Arrange
            List<string[]> datos = null;

            var SUT = new ValidadorArchivoPedidosService();

            // Act
            try
            {
                var resultado = SUT.validarPlantillaPedidos(datos);
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
