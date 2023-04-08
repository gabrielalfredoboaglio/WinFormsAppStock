
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

        public int AgregarEnDb()
        {
            string query = $"insert into deposito (Capacidad, Nombre, Direccion)";
            query += $" values ({Capacidad.ToString("0.00", CultureInfo.InvariantCulture)}, '{Nombre}', '{Direccion}')";
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

        public int ActualizarEnDb(Deposito depositoAModificar)
        {
            string query = $"update deposito set Nombre = '{depositoAModificar.Nombre}', " +
                           $"Direccion='{depositoAModificar.Direccion}', " +
                           $"Capacidad={depositoAModificar.Capacidad.ToString("0.00", CultureInfo.InvariantCulture)} " +
                           $"where id = {depositoAModificar.Id}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }

        }
        public int EliminarEnDb(int idDepositoEliminar)
        {
            string query = $"delete deposito where Id={idDepositoEliminar}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }

        }
        public Deposito GetDepositoPorId(int depositoId)
        {
            try
            {
                string select = $"select * from Deposito where id={depositoId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    // no se encuentra deposito con ese ID
                    return null;
                }

                Deposito depositoADevolverConDatosDeLaBaseDeDatos = new Deposito();
                foreach (DataRow dr in dt.Rows)
                {
                    depositoADevolverConDatosDeLaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    depositoADevolverConDatosDeLaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    depositoADevolverConDatosDeLaBaseDeDatos.Direccion = dr["Direccion"].ToString();
                    depositoADevolverConDatosDeLaBaseDeDatos.Capacidad = Convert.ToDecimal(dr["Capacidad"]);
                }

                return depositoADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                // error al intentar buscar el deposito por ID
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        public List<Deposito> GetTodosLosDepositos()
        {
            try
            {
                string select = $"select * from deposito";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);
                if (dt.Rows.Count <= 0)
                {
                    return null;
                }

                List<Deposito> depositosADevolverConDatosDeLaBaseDeDatos = new List<Deposito>();
                foreach (DataRow dr in dt.Rows)
                {
                    Deposito depositoAuxiliar = new Deposito();
                    depositoAuxiliar.Id = Convert.ToInt32(dr["Id"]);
                    depositoAuxiliar.Nombre = dr["Nombre"].ToString();
                    depositoAuxiliar.Direccion = dr["Direccion"].ToString();
                    depositosADevolverConDatosDeLaBaseDeDatos.Add(depositoAuxiliar);
                }

                return depositosADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }



    }
}








