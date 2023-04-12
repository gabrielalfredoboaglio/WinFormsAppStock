
using CodigoComun.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelos
{
    public class Deposito
    {
        public int Id { get; set; }
        public decimal Capacidad { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }

        private AccesoDatos ac;
        public Deposito()
        {
            ac = new AccesoDatos();
        }

      
        public string MostrarVariblesPrincipales()
        {
            return "El numero del deposito es " + Id + " Nombre: " + Nombre;

        }

        public string MostrarTodasVaribles()
        {
            return $"El numero del deposito es {Id}, Capacidad {Capacidad}, Nombre {Nombre}, " +
                $"Direccion {Direccion} ";

        }

  

    }
}








