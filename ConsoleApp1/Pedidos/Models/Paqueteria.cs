using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Pedidos.Models
{
    public class Paqueteria : IPaqueteria
    {

        private string nombre;
        private decimal utilidad;
        private List<IMedioTransporte> mediosTransporte;

        public Paqueteria(string nombre, List<IMedioTransporte> mediosTransporte, decimal utilidad)
        {
            this.nombre = nombre;
            this.mediosTransporte = mediosTransporte;
            this.utilidad = utilidad;
        }

        public List<IMedioTransporte> getMediosTransporte()
        {
            return mediosTransporte;
        }

        public string getNombre()
        {
            return nombre;
        }

        public bool tienesMedioTransporte(string nombre)
        {
            foreach(var medio in mediosTransporte)
            {
                if (nombre.Equals(medio.getMedio()))
                    return true;
            }

            return false;
        }

        public IMedioTransporte getMedioTransporte(string nombre)
        {
            foreach (var medio in mediosTransporte)
            {
                if (nombre.Equals(medio.getMedio()))
                    return medio;
            }

            return null;
        }

        public decimal getUtilidad()
        {
            return this.utilidad;
        }
    }
}
