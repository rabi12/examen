using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public class CalculadorDiferenciaFechasEnMeses : ICalculadorDiferenciaFechasEnMeses
    {
        public  int calcularDiferencia(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1 > fecha2)
            {
                TimeSpan ts = fecha1 - fecha2;
                if(ts.Days>=30)
                    return -(ts.Days/30);
            }
            else
            {
                TimeSpan ts = fecha2 - fecha1;
                if(ts.Days>=30)
                return (ts.Days/30);
            }

            return 0;
        }
    }
}
