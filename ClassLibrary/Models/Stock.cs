using System.ComponentModel.DataAnnotations.Schema;

namespace CodigoComun.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdDeposito { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual Deposito IdDepositoNavigation { get; set; }

        [NotMapped]
        public object ArticuloGuardado { get;  set; }

        [NotMapped]
        public object DepositoDondeEstaGuardado { get;  set; }
    }
}
