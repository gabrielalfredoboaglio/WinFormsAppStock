using CodigoComun.Modelos;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodigoComun.Datos;

namespace CodigoComun.Negocio
{
    public class ArticuloService
    {


        private ArticuloRepository articuloRepository = new ArticuloRepository();




        public string AgregarArticulo(Articulo ArticuloAAgregar)
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();

            try
            {
                // Validar que no exista un artículo con el mismo código
                if (articuloRepository.GetArticuloPorCodigo(ArticuloAAgregar.Codigo) != null)
                {
                    return "Ya existe un artículo con ese código.";
                }

                // Agregar el artículo a la base de datos
                int r = articuloRepository.AddArticuloDB(ArticuloAAgregar);

                if (r == 1)
                {
                    return "Articulo Agregado";
                }
                else
                {
                    return "No se pudo Agregar el articulo";
                }
            }
            catch (Exception ex)
            {
                // Retornar un mensaje de error detallado en caso de excepción
                return $"Error al agregar el Articulo a la base de datos. Detalles del error: {ex.Message}";
            }
        }



        public string ActualizarArticulo(Articulo articuloAActualizar)
        {
            int resultado = articuloRepository.ActualizarEnDb(articuloAActualizar);
            if (resultado == 1)
            {
                return "Articulo Actualizado";
            }
            else
            {
                return "No se pudo Actualizar el articulo";
            }
        }

        public string EliminarArticulo(int idArticuloEliminar)
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();
            int resultado = articuloRepository.EliminarEnDb(idArticuloEliminar);

            if (resultado == 1)
            {
                return "Articulo eliminado correctamente";
            }
            else
            {
                return "Error al eliminar el articulo";
            }
        }

    

        public List<Articulo> ObtenerTodosLosArticulos()
        {
            return articuloRepository.GetTodosLosArticulos();
        }

        public Articulo GetArticuloPorId(int articuloId)
        {
            return articuloRepository.GetArticuloPorId(articuloId);
        }

        public Articulo ObtenerArticuloPorNombre(string nombre)
        {
            return articuloRepository.GetArticuloPorNombre(nombre);
        }

    }
}

