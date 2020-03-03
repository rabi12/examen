using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class ValidadorArchivosEventosServiceUTest
    {
        [TestMethod]
        public void validarPlantillaEventos_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos  = new List<string[]>();
            datos.Add(new string[] {"Merida","Tizimin","200","MercadoLibre","Avion","23-03-2020 12:00:00","Evento mas datos" });
            
            var SUT = new ValidadorArchivoPedidosService();
            
            // Act
            var resultado=SUT.validarPlantillaPedidos(datos);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_FormatoIncorrectoMenosDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento menos datos", "Tizimin", "200", "MercadoLibre" });

            var SUT = new ValidadorArchivoPedidosService();

            // Act
            var resultado = SUT.validarPlantillaPedidos(datos);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_FormatoCorrecto_True()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Merida", "Tizimin", "200", "DHL", "Avion", "23 - 03 - 2020 12:00:00" });

            var SUT = new ValidadorArchivoPedidosService();

            // Act
            var resultado = SUT.validarPlantillaPedidos(datos);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_Null_Excpetion()
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
//