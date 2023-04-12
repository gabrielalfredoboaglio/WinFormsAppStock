using CodigoComun.Models;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Negocio
{
    public class DepositoServices
    {

        public List<Deposito> ObtenerTodosLosDepositos()
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            return depositoRepository.GetTodosLosDepositos();
        }

        public string EliminarDeposito(int idDepositoEliminar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            int resultado = depositoRepository.EliminarDeposito(idDepositoEliminar);

            if (resultado == 1)
            {
                return "Depósito eliminado correctamente";
            }
            else
            {
                return "Error al eliminar el depósito";
            }
        }

        public Deposito ObtenerDepositoPorId(int idDeposito)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            return depositoRepository.GetDepositoPorId(idDeposito);
        }

        public int AddDeposito(Deposito depositoAAgregar)
        {
            try
            {
                using (var db = new StockAppContext())
                {
                    db.Depositos.Add(depositoAAgregar);
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar depósito a la base de datos: {ex.Message}");
                return -1;
            }


        }

        public int ModificarDeposito(Deposito depositoAModificar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            int resultado = depositoRepository.ActualizarDeposito(depositoAModificar);

            if (resultado == 1)
            {
                return resultado;
            }
            else
            {
                return -1;
            }
        }

    }
}
