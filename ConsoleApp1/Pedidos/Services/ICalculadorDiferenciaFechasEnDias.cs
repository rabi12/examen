using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Services
{
    public interface ICalculadorDiferenciaFechasEnDias
    {
        int calcularDiferencia(DateTime fecha1, DateTime fecha2);
    }
}
