using ConsoleApp1.Pedidos.Models;
using ConsoleApp1.Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Controllers
{
    public class DiferenciaFechasController
    {
        ICalculadorDiferenciaFechasEnMeses calculadorMeses;
        ICalculadorDiferenciaFechasEnDias calculadorDias;
        ICalculadorDiferenciaFechasEnHoras calculadorHoras;
        ICalculadorDiferenciaFechasEnMinutos calculadorMinutos;

        public DiferenciaFechasController( 
            ICalculadorDiferenciaFechasEnMeses calculadorMeses, ICalculadorDiferenciaFechasEnDias calculadorDias, 
            ICalculadorDiferenciaFechasEnHoras calculadorHoras, ICalculadorDiferenciaFechasEnMinutos calculadorMinutos)
        {
            this.calculadorMeses = calculadorMeses;
            this.calculadorDias = calculadorDias;
            this.calculadorHoras= calculadorHoras;
            this.calculadorMinutos = calculadorMinutos;
        }

        
        public string obtenerRangoTiempo(DateTime fechaPedido, DateTime fechaActual)
        {
            int diferenciaTiempo = 0;
            string diferenciaRango = "Mes(es)";
            string cadena = "";

            diferenciaTiempo = calcularDiferenciaEnMeses(fechaActual, fechaPedido);
            if (diferenciaTiempo == 0)
            {
                diferenciaRango = "Dia(s)";
                diferenciaTiempo = calcularDiferenciaEnDias(fechaActual, fechaPedido);
                if (diferenciaTiempo == 0)
                {
                    diferenciaRango = "Hora(s)";
                    diferenciaTiempo = calcularDiferenciaEnHoras(fechaActual, fechaPedido);
                    if (diferenciaTiempo == 0)
                    {
                        diferenciaRango = "Minuto(s)";
                        diferenciaTiempo = calcularDiferenciaEnMinutos(fechaActual, fechaPedido);
                    }
                }
            }

            if (diferenciaTiempo > 0)
            {
                cadena += diferenciaTiempo + " " + diferenciaRango;
            }
            else
                cadena += Math.Abs(diferenciaTiempo) + " " + diferenciaRango;
            return cadena;
        }

        private int calcularDiferenciaEnMeses(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorMeses.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnDias(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorDias.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnHoras(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorHoras.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnMinutos(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorMinutos.calcularDiferencia(fecha1, fecha2);
        }
    }
}
