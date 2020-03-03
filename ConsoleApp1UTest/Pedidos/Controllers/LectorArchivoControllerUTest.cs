using ConsoleApp1.Pedidos.Controllers;
using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Controllers
{
    [TestClass]
    public class LectorArchivoControllerUTest
    {
        [TestMethod]
        public void obtenerDatosArchivo_RutaArchivoIncorrecta_Exception()
        {
            //Arrange
            var DOClectorArchivoService = new Mock<ILectorArchivoService>();
            DOClectorArchivoService.Setup(DOC => DOC.leerArchivo(It.IsAny<string>())).Throws(new Exception(""));
            
            var SUT = new LectorArchivoController(DOClectorArchivoService.Object);

            // Act
            try
            {
                SUT.obtenerDatosArchivo("Any.cs");
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "No existe el archivo en la ruta especificada");
                return;
            }

            Assert.Fail("No se lanzo ninguna excepcion.");
        }
    }
}
