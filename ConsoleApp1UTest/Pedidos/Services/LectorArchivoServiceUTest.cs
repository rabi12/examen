using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class LectorArchivoServiceUTest
    {
        [TestMethod]
        public void leerArchivo_RutaArchivoIncorrecta_Exception()
        {
            //Arrange
            var SUT = new LectorArchivoService();
            
            // Act
            try
            {
                SUT.leerArchivo("Any.cs");
            }
            catch (Exception e)
            {
                // Assert
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail("No se lanzo ninguna excepcion.");
        }
    }
}
