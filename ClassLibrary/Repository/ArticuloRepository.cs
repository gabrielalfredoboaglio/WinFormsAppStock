﻿using CodigoComun.Datos;
using CodigoComun.Modelos;
using CodigoComun.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodigoComun.Repository
{
    public class ArticuloRepository


    {
        private AccesoDatos ac = new AccesoDatos();





        public int AddArticuloDB(Articulo ArticuloAAgregar)
        {
            string query = "INSERT INTO articulo (Nombre, Marca, MinimoStock, Proveedor, Precio, Codigo) " +
                "VALUES (@Nombre, @Marca, @MinimoStock, @Proveedor, @Precio, @Codigo)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nombre", ArticuloAAgregar.Nombre);
            command.Parameters.AddWithValue("@Marca", ArticuloAAgregar.Marca);
            command.Parameters.AddWithValue("@MinimoStock", ArticuloAAgregar.MinimoStock);
            command.Parameters.AddWithValue("@Proveedor", ArticuloAAgregar.Proveedor);
            command.Parameters.AddWithValue("@Precio", ArticuloAAgregar.Precio);
            command.Parameters.AddWithValue("@Codigo", ArticuloAAgregar.Codigo);

            try
            {
                ac.Conectar();
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

        public int ActualizarEnDb(Articulo articuloAActualizar)
        {
            string query = "UPDATE articulo SET " +
                           "Nombre = @Nombre, " +
                           "Marca = @Marca, " +
                           "MinimoStock = @MinimoStock, " +
                           "Proveedor = @Proveedor, " +
                           "Precio = @Precio, " +
                           "Codigo = @Codigo " +
                           "WHERE id = @Id";

            try
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@Nombre", articuloAActualizar.Nombre);
                command.Parameters.AddWithValue("@Marca", articuloAActualizar.Marca);
                command.Parameters.AddWithValue("@MinimoStock", articuloAActualizar.MinimoStock);
                command.Parameters.AddWithValue("@Proveedor", articuloAActualizar.Proveedor);
                command.Parameters.AddWithValue("@Precio", articuloAActualizar.Precio);
                command.Parameters.AddWithValue("@Codigo", articuloAActualizar.Codigo);
                command.Parameters.AddWithValue("@Id", articuloAActualizar.Id);

                ac.Conectar();
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




        public class ArticuloAsociadoConStockException : Exception
        {
            public ArticuloAsociadoConStockException(string mensaje) : base(mensaje)
            {
            }
        }

        public int EliminarEnDb(int idArticuloEliminar)
        {
            string query = $"delete articulo where id={idArticuloEliminar}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    throw new ArticuloAsociadoConStockException("No se puede eliminar el artículo porque está asociado con un stock");
                }
                else
                {
                    throw ex;
                }
            }
            finally
            {
                ac.DesConectar();
            }
        }



        public List<Articulo> GetTodosLosArticulos()
        {
            try
            {
                string select = "SELECT Id, Nombre, Precio,Marca,MinimoStock,Proveedor, Codigo FROM articulo";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    return null;
                }

                List<Articulo> articulos = new List<Articulo>();

                foreach (DataRow row in dt.Rows)
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = Convert.ToInt32(row["Id"]);
                    articulo.Nombre = row["Nombre"].ToString();
                    articulo.Marca = row["Marca"].ToString();
                    articulo.MinimoStock = Convert.ToInt32(row["MinimoStock"]);
                    articulo.Proveedor = row["Proveedor"].ToString();
                    articulo.Precio = Convert.ToDecimal(row["Precio"]);
                    articulo.Codigo = row["Codigo"].ToString();
                    articulos.Add(articulo);
                }

                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Articulo GetArticuloPorId(int articuloId)
        {
            try
            {
                string select = $"select * from Articulo where id={articuloId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    // no se encuentra articulo con ese ID
                    return null;
                }

                Articulo articuloADevolverConDatosDeLaBaseDeDatos = new Articulo();
                foreach (DataRow dr in dt.Rows)
                {
                    articuloADevolverConDatosDeLaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Marca = dr["Marca"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Precio = Convert.ToDecimal(dr["Precio"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.MinimoStock = Convert.ToInt32(dr["MinimoStock"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.Proveedor = dr["Proveedor"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Codigo = dr["Codigo"].ToString();
                }

                return articuloADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                // error al intentar buscar el articulo por ID
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        public Articulo GetArticuloPorCodigo(string codigo)
        {
            try
            {
                string select = $"select * from Articulo where Codigo='{codigo}'";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    // no se encuentra articulo con ese codigo
                    return null;
                }

                Articulo articuloADevolverConDatosDeLaBaseDeDatos = new Articulo();
                foreach (DataRow dr in dt.Rows)
                {
                    articuloADevolverConDatosDeLaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Marca = dr["Marca"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Precio = Convert.ToDecimal(dr["Precio"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.MinimoStock = Convert.ToInt32(dr["MinimoStock"]);
                    articuloADevolverConDatosDeLaBaseDeDatos.Proveedor = dr["Proveedor"].ToString();
                    articuloADevolverConDatosDeLaBaseDeDatos.Codigo = dr["Codigo"].ToString();
                }

                return articuloADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                // error al intentar buscar el articulo por codigo
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }
        public Articulo GetArticuloPorNombre(string nombreArticulo)
        {
            try
            {
                string select = $"SELECT * FROM Articulo WHERE Nombre = '{nombreArticulo}'";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    // no se encuentra articulo con ese nombre
                    return null;
                }

                DataRow dr = dt.Rows[0];
                Articulo articuloADevolverConDatosDeLaBaseDeDatos = new Articulo()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Nombre = dr["Nombre"].ToString(),
                    Marca = dr["Marca"].ToString(),
                    Precio = Convert.ToDecimal(dr["Precio"]),
                    MinimoStock = Convert.ToInt32(dr["MinimoStock"]),
                    Proveedor = dr["Proveedor"].ToString(),
                    Codigo = dr["Codigo"].ToString()
                };

                return articuloADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                // error al intentar buscar el articulo por nombre
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }



    }

}








