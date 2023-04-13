using CodigoComun.Datos;
using CodigoComun.Negocio;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelos
{
    public class Stock
    {

        public int Id { get; set; }

        public int IdDeposito { get; set; }
        public int IdArticulo { get; set; }
        public Articulo ArticuloGuardado { get; set; }

        public Deposito DepositoDondeEstaGuardado { get; set; }
        public DepositoServices depositoServices = new DepositoServices();
        public decimal Cantidad { get; set; }

        private AccesoDatos ac;

        private ArticuloRepository articuloRepository = new ArticuloRepository();

        public Stock()
        {
            ac = new AccesoDatos();
        }
    }
}
