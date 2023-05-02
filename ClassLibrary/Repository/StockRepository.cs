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
                var stock = context.Stocks.FirstOrDefault(s => s.Id == stockId);
                if (stock != null)
                {
                    var articulo = context.Stocks.FirstOrDefault(a => a.Id == stock.IdArticulo);
                    stock.ArticuloGuardado = articulo;

                    var deposito = context.Depositos.FirstOrDefault(d => d.Id == stock.IdDeposito);
                    stock.DepositoDondeEstaGuardado = deposito;
                }

                return stock;
            }
        }



        public List<Stock> ObtenerTodosLosStocks()
        {
            try
            {
                return db.Stocks.ToList();
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
        public List<Stock> ObtenerTodosLosStocksPorDeposito(int idDeposito)
        {
            using (var context = new StockAppContext())
            {
                var stocks = context.Stocks.Where(s => s.IdDeposito == idDeposito).ToList();
                foreach (var stock in stocks)
                {
                    var articulo = context.Stocks.FirstOrDefault(a => a.Id == stock.IdArticulo);
                    stock.ArticuloGuardado = articulo;

                    var deposito = context.Depositos.FirstOrDefault(d => d.Id == stock.IdDeposito);
                    stock.DepositoDondeEstaGuardado = deposito;
                }

                return stocks;
            }
        }

        public List<Stock> ObtenerTodosLosStocksPorArticulo(int idArticulo)
        {
            using (var context = new StockAppContext())
            {
                var stocks = context.Stocks.Where(s => s.IdArticulo == idArticulo).ToList();
                foreach (var stock in stocks)
                {
                    var articulo = context.Stocks.FirstOrDefault(a => a.Id == stock.IdArticulo);
                    stock.ArticuloGuardado = articulo;

                    var deposito = context.Depositos.FirstOrDefault(d => d.Id == stock.IdDeposito);
                    stock.DepositoDondeEstaGuardado = deposito;
                }

                return stocks;
            }
        }
    }
}
