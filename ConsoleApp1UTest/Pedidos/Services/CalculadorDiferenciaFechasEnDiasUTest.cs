using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class CalculadorDiferenciaFechasEnDiasUTest
    {
        [TestMethod]
        public void calcularDiferencia_FechaFutura_NumeroPositivo()
        {
            //Arrange 
            var fecha1 = new DateTime(2019, 12, 1);
            var fecha2 = new DateTime(2019, 12, 20);
            var SUT = new CalculadorDiferenciaFechasEnDias();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1,fecha2);

            //Assert
            Assert.AreEqual(19, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaPasada_NumeroNegativo()
        {
            //Arrange 
            var fecha1 = new DateTime(2019, 12, 20);
            var fecha2 = new DateTime(2019, 12, 1);
            var SUT = new CalculadorDiferenciaFechasEnDias();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(-19, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaPasadaConHora_NumeroNegativo()
        {
            //Arrange 
            var fecha1 = new DateTime(2019, 12, 20,9,30,30);
            var fecha2 = new DateTime(2019, 12, 1,10,20,10);
            var SUT = new CalculadorDiferenciaFechasEnDias();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(-18, resultado);
        }
    }
}
