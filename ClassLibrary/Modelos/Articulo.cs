

using CodigoComun.Datos;
using CodigoComun.Modelos.DTO;
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
    public class Articulo
    {
        //defino mis atributos 
        public int Id { get; set; }
        public string Nombre { set; get; }

        public string Marca { get; set; }

        public decimal MinimoStock { get; set; }
        public string Proveedor { get; set; }

        public decimal Precio { get; set; }

        public string Codigo { get; set; }


        private AccesoDatos ac;

        public StockDTO Stock { get; set; }
        public Articulo()
        {
            ac = new AccesoDatos();
        }



        //Metodos 
        public string MostrarVariblesPrincipales()
        {
            return "Numero/Id " + Id + " Nombre: "
                + Nombre + " Marca: " + Marca;
        }

        public string MostrarTodasVariables()
        {
            return $"Numero/Id {Id} - Nombre {Nombre} - Marca {Marca} - Minimo Stock {MinimoStock} " +
                   $"- Proveedor {Proveedor} - Precio {Precio} - Codigo {Codigo}";
        }



    }
}
