
using CodigoComun.Datos;
using CodigoComun.Modelos;
using CodigoComun.Negocio;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Models
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


        public int AgregarEnDb()
        {
            string query = $"INSERT INTO Stocks (IdArticulo, IdDeposito, Cantidad) VALUES ({ArticuloGuardado.Id}, {DepositoDondeEstaGuardado.Id}, {Cantidad.ToString("0.00", CultureInfo.InvariantCulture)})";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }

        }
        public int ActualizarEnDb(Stock stockAModificar)
        {
            if (ArticuloGuardado == null)
            {
                throw new ArgumentNullException(nameof(ArticuloGuardado), "El objeto ArticuloGuardado es nulo.");
            }

            if (DepositoDondeEstaGuardado == null)
            {
                throw new ArgumentNullException(nameof(DepositoDondeEstaGuardado), "El objeto DepositoDondeEstaGuardado es nulo.");
            }


            string query = $"UPDATE Stocks SET IdArticulo={ArticuloGuardado.Id}, IdDeposito={DepositoDondeEstaGuardado.Id}, Cantidad={Cantidad.ToString("0.00", CultureInfo.InvariantCulture)} WHERE Id={Id}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }
        }
        public int EliminarEnDb()
        {
            string query = $"DELETE FROM Stocks WHERE Id={Id}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        public Stock GetStockPorId(int stockId)
        {
            try
            {

                string select = $"SELECT * FROM Stocks WHERE Id={stockId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    // no se encuentra stock con ese ID
                    return null;
                }

                Stock stockADevolverConDatosDeLaBaseDeDatos = new Stock();
                foreach (DataRow dr in dt.Rows)
                {
                    stockADevolverConDatosDeLaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    stockADevolverConDatosDeLaBaseDeDatos.ArticuloGuardado = articuloRepository.GetArticuloPorId(Convert.ToInt32(dr["ArticuloId"]));

                    stockADevolverConDatosDeLaBaseDeDatos.DepositoDondeEstaGuardado = depositoServices.ObtenerDepositoPorId(Convert.ToInt32(dr["DepositoId"]));
                    stockADevolverConDatosDeLaBaseDeDatos.Cantidad = Convert.ToDecimal(dr["Cantidad"]);
                }

                return stockADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // error al intentar buscar el stock por ID
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }


        public List<Stock> ObtenerTodosLosStocks()
        {
            try
            {
                string select = "SELECT * FROM Stocks";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                List<Stock> listaStocks = new List<Stock>();
                foreach (DataRow dr in dt.Rows)
                {
                    Stock stock = new Stock();
                    stock.Id = Convert.ToInt32(dr["Id"]);
                    stock.ArticuloGuardado = articuloRepository.GetArticuloPorId(Convert.ToInt32(dr["IdArticulo"]));
                    stock.DepositoDondeEstaGuardado = depositoServices.ObtenerDepositoPorId(Convert.ToInt32(dr["IdDeposito"]));
                    stock.Cantidad = Convert.ToDecimal(dr["Cantidad"]);

                    listaStocks.Add(stock);
                }

                return listaStocks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }
    }

    }



