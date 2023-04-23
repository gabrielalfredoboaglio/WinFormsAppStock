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
using CodigoComun.Modelos.DTO;

namespace CodigoComun.Negocio
{
    public class ArticuloService
    {


        private ArticuloRepository articuloRepository = new ArticuloRepository();




        public ArticuloDTO AgregarArticulo(ArticuloDTO articuloDTOAAgregar)
        {
            try
            {
                ArticuloRepository articuloRepository = new ArticuloRepository();

                Articulo articuloAuxiliar = articuloRepository.GetArticuloPorId(articuloDTOAAgregar.Id);

                if (articuloAuxiliar != null)
                {
                    articuloDTOAAgregar.HuboError = true;
                    articuloDTOAAgregar.Mensaje = $"Ya existe un articulo con ese Id {articuloDTOAAgregar.Id}";
                    return articuloDTOAAgregar;
                }

                Articulo articulo = articuloDTOAAgregar.GetArticulo(articuloDTOAAgregar);

                int r = articuloRepository.AddArticuloDB(articulo);

                if (r == 1)
                {
                    articuloDTOAAgregar.Mensaje = "Articulo Agregado";
                    return articuloDTOAAgregar;
                }
                else
                {
                    articuloDTOAAgregar.Mensaje = "No se pudo agregar el  Articulo";
                    return articuloDTOAAgregar;
                }
            }
            catch (Exception ex)
            {
                articuloDTOAAgregar.HuboError = true;
                articuloDTOAAgregar.Mensaje = $"Hubo una excepcion dando el alta del articulo {ex.Message}";
                return articuloDTOAAgregar;
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

