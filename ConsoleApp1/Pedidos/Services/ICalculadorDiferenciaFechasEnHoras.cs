using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface ICalculadorDiferenciaFechasEnHoras
    {
        int calcularDiferencia(DateTime fecha1, DateTime fecha2);
    }
}
