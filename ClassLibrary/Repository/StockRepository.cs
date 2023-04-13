using CodigoComun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Repository
{
    public class StockRepository
    {
        StockAppContext db = new StockAppContext();

        public int AddStock(Stock stockAAgregar)
        {
            using (var context = new StockAppContext())
            {
                context.Stocks.Add(stockAAgregar);
                return context.SaveChanges();
            }
        }

        public Stock GetStockPorId(int stockId)
        {
            using (var context = new StockAppContext())
            {
                return context.Stocks
                              .Include(s => s.ArticuloGuardado)
                              .Include(s => s.DepositoDondeEstaGuardado)
                              .FirstOrDefault(s => s.Id == stockId);
            }
        }

        public List<Stock> ObtenerTodosLosStocks()
        {
            try
            {
                return db.Stocks.Include(s => s.ArticuloGuardado)
                                .Include(s => s.DepositoDondeEstaGuardado)
                                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public int EliminarStock(int idStock)
        {
            using (var context = new StockAppContext())
            {
                try
                {
                    var stockAEliminar = context.Stocks.Find(idStock);
                    if (stockAEliminar != null)
                    {
                        context.Stocks.Remove(stockAEliminar);
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
        public int ActualizarStock(Stock stockAModificar)
        {
            using (var context = new StockAppContext())
            {
                try
                {
                    context.Entry(stockAModificar).State = EntityState.Modified;
                    return context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

    }
}
