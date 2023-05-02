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
using AutoMapper;
using System.Runtime.CompilerServices;

namespace CodigoComun.Negocio
{
    public class ArticuloService
    {


        private ArticuloRepository articuloRepository = new ArticuloRepository();

       
        private readonly IMapper _mapper;


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

                Articulo articuloPorCodigo = articuloRepository.GetArticuloPorCodigo(articuloDTOAAgregar.Codigo);

                if (articuloPorCodigo != null)
                {
                    articuloDTOAAgregar.HuboError = true;
                    articuloDTOAAgregar.Mensaje = $"Ya existe un artículo con ese código {articuloDTOAAgregar.Codigo}";
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
                    articuloDTOAAgregar.Mensaje = "No se pudo agregar el Articulo";
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





        public ArticuloDTO ActualizarArticulo(ArticuloDTO articuloAActualizar)
        {
            try
            {
                Articulo articulo = articuloAActualizar.GetArticulo(articuloAActualizar);
                int resultado = articuloRepository.ActualizarEnDb(articulo);
                if (resultado == 1)
                {
                    articuloAActualizar.Mensaje = "Articulo Actualizado";
                    return articuloAActualizar;
                }
                else
                {
                    articuloAActualizar.HuboError = true;
                    articuloAActualizar.Mensaje = "No se pudo Actualizar el articulo";
                    return articuloAActualizar;
                }
            }
            catch (Exception ex)
            {
                articuloAActualizar.HuboError = true;
                articuloAActualizar.Mensaje = $"Hubo una excepcion actualizando el articulo {ex.Message}";
                return articuloAActualizar;
            }
        }

        public List<ArticuloDTO> ObtenerTodosLosArticulos()
        {
            var articulos = articuloRepository.GetTodosLosArticulos();
            var articulosDTO = new List<ArticuloDTO>();

            foreach (var articulo in articulos)
            {
                articulosDTO.Add(new ArticuloDTO
                {
                    Id = articulo.Id,
                    Nombre = articulo.Nombre,
                    Marca = articulo.Marca,
                    MinimoStock = articulo.MinimoStock,
                    Proveedor = articulo.Proveedor,
                    Precio = articulo.Precio,
                    Codigo = articulo.Codigo
                });
            }

            return articulosDTO;
        }
        public ArticuloDTO EliminarArticulo(int idArticuloEliminar)
        {
            ArticuloRepository articuloRepository = new ArticuloRepository();
            int resultado = articuloRepository.EliminarEnDb(idArticuloEliminar);

            if (resultado == 1)
            {
                return new ArticuloDTO { Mensaje = "Articulo eliminado correctamente" };
            }
            else
            {
                return new ArticuloDTO { Mensaje = "Error al eliminar el articulo" };
            }
        }



       

        public ArticuloDTO GetArticuloPorId(int articuloId)
        {
            var articulo = articuloRepository.GetArticuloPorId(articuloId);
            if (articulo == null)
            {
                throw new Exception($"No se encontró el Articulo con Id {articuloId}");
            }

            return new ArticuloDTO
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Marca = articulo.Marca,
                MinimoStock = articulo.MinimoStock,
                Proveedor = articulo.Proveedor,
                Precio = articulo.Precio,
                Codigo = articulo.Codigo
            };
        }


        public ArticuloDTO GetArticuloPorNombre(string nombreArticulo)
        {
            ArticuloDTO articuloDTO = null;
            Articulo articulo = articuloRepository.GetArticuloPorNombre(nombreArticulo);
            if (articulo != null)
            {
                articuloDTO = new ArticuloDTO
                {
                    Id = articulo.Id,
                    Nombre = articulo.Nombre,
                    Marca = articulo.Marca,
                    MinimoStock = articulo.MinimoStock,
                    Proveedor = articulo.Proveedor,
                    Precio = articulo.Precio,
                    Codigo = articulo.Codigo
                };
            }
            return articuloDTO;
        }


    }
}

