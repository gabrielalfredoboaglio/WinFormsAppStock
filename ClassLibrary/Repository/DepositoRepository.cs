using CodigoComun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Repository
{
    public class DepositoRepository
    {

        public int AddDeposito(Deposito depositoAAgregar)
        {

            StockAppContext db = new StockAppContext();
            db.Depositos.Add(depositoAAgregar);
            return db.SaveChanges();

        }

        public Deposito GetDepositoPorId(int idDeposito)
        {
            using (var context = new StockAppContext())
            {
                return context.Depositos.FirstOrDefault(d => d.Id == idDeposito);
            }
        }


        public List<Deposito> GetTodosLosDepositos()
        {
            StockAppContext db = new StockAppContext();
            List<Deposito> depositos = new List<Deposito>();  
            

            depositos =db.Depositos.ToList();

            return depositos;
        }

        public int EliminarDeposito(int idDeposito)
        {
            using (var context = new StockAppContext())
            {
                try
                {
                    var depositoAEliminar = context.Depositos.Find(idDeposito);
                    if (depositoAEliminar != null)
                    {
                        context.Depositos.Remove(depositoAEliminar);
                        return context.SaveChanges();
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }


        }

       
    }
}
