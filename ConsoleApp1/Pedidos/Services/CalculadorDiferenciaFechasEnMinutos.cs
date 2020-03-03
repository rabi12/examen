using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class CalculadorDiferenciaFechasEnMinutos : ICalculadorDiferenciaFechasEnMinutos
    {
        public  int calcularDiferencia(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1 > fecha2)
            {
                TimeSpan ts = fecha1 - fecha2;
                return -(ts.Minutes);
            }
            else
            {
                TimeSpan ts = fecha2 - fecha1;
                return ts.Minutes;
            }
        }
    }
}
