using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class CalculadorDiferenciaFechasEnDias : ICalculadorDiferenciaFechasEnDias
    {
        public  int calcularDiferencia(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1 > fecha2)
            {
                TimeSpan ts = fecha1 - fecha2;
                return -(ts.Days);
            }
            else
            {
                TimeSpan ts = fecha2 - fecha1;
                return ts.Days;
            }
        }
    }
}
