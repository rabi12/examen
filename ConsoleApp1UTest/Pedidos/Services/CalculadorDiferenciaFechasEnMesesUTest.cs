using ConsoleApp1.Pedidos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class CalculadorDiferenciaFechasEnMesesUTest
    {
        [TestMethod]
        public void calcularDiferencia_FechaFutura_Cero()
        {
            //Arrange  Menos de 30 dias
            var fecha1 = new DateTime(2019, 12, 1);
            var fecha2 = new DateTime(2019, 12, 20);
            var SUT = new CalculadorDiferenciaFechasEnMeses();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1,fecha2);

            //Assert
            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaFutura_NumeroPositivo()
        {
            //Arrange  Mas de 30 dias
            var fecha1 = new DateTime(2019, 12, 1);
            var fecha2 = new DateTime(2020, 01, 01);
            var SUT = new CalculadorDiferenciaFechasEnMeses();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaPasada_NumeroNegativo()
        {
            //Arrange  Menos 30 dias
            var fecha1 = new DateTime(2020, 01, 01);
            var fecha2 = new DateTime(2019, 12, 1);
            var SUT = new CalculadorDiferenciaFechasEnMeses();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(-1, resultado);
        }

    }
}
