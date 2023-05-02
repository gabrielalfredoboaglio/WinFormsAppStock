using CodigoComun.Modelos.DTO;
using CodigoComun.Models;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Negocio
{
    public class DepositoService
    {
        public DepositoDTO AgregarDeposito(DepositoDTO depositoDTOAAgregar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();

            try
            {
                // Obtener una lista de todos los depósitos existentes en la base de datos
                var depositosExistentes = depositoRepository.GetTodosLosDepositos();

                // Verificar si el nombre del depósito a agregar ya existe en la lista obtenida
                if (depositosExistentes.Any(d => d.Nombre == depositoDTOAAgregar.Nombre))
                {
                    return new DepositoDTO
                    {
                        Mensaje = "No se puede agregar el depósito porque ya existe uno con el mismo nombre",
                        HuboError = true
                    };
                }

                // Agregar el depósito a la base de datos
                var deposito = depositoDTOAAgregar.GetDeposito(depositoDTOAAgregar);
                int r = depositoRepository.AddDeposito(deposito);

                if (r == 1)
                {
                    depositoDTOAAgregar.Mensaje = "Depósito agregado";
                    return depositoDTOAAgregar;
                }
                else
                {
                    depositoDTOAAgregar.Mensaje = "No se pudo agregar el depósito";
                    return depositoDTOAAgregar;
                }
            }
            catch (Exception ex)
            {
                depositoDTOAAgregar.HuboError = true;
                depositoDTOAAgregar.Mensaje = $"Hubo una excepción dando de alta el depósito {ex.Message}";
                return depositoDTOAAgregar;
            }
        }





        public DepositoDTO ModificarDeposito(DepositoDTO depositoAModificar)
        {
            try
            {
                Deposito deposito = depositoAModificar.GetDeposito(depositoAModificar);
                DepositoRepository depositoRepository = new DepositoRepository();
                int resultado = depositoRepository.ActualizarDeposito(deposito);

                if (resultado == 1)
                {
                    depositoAModificar.Mensaje = "Deposito Actualizado";
                    return depositoAModificar;
                }
                else
                {
                    depositoAModificar.HuboError = true;
                    depositoAModificar.Mensaje = "No se pudo Actualizar el deposito";
                    return depositoAModificar;
                }
            }
            catch (Exception ex)
            {
                depositoAModificar.HuboError = true;
                depositoAModificar.Mensaje = $"Hubo una excepcion actualizando el deposito {ex.Message}";
                return depositoAModificar;
            }
        }

        public DepositoDTO EliminarDeposito(int idDepositoEliminar)
        {
            try
            {
                DepositoRepository depositoRepository = new DepositoRepository();
                int resultado = depositoRepository.EliminarDeposito(idDepositoEliminar);

                if (resultado == 1)
                {
                    return new DepositoDTO { Mensaje = "Depósito eliminado correctamente" };
                }
                else
                {
                    return new DepositoDTO { Mensaje = "Error al eliminar el depósito" };
                }
            }
            catch (Exception ex)
            {
                return new DepositoDTO { HuboError = true, Mensaje = $"Hubo una excepción eliminando el depósito: {ex.Message}" };
            }
        }




        public List<DepositoDTO> ObtenerTodosLosDepositos()
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            var depositos = depositoRepository.GetTodosLosDepositos();
            var depositosDTO = new List<DepositoDTO>();

            foreach (var deposito in depositos)
            {
                depositosDTO.Add(new DepositoDTO
                {
                    Id = deposito.Id,
                    Capacidad = deposito.Capacidad,
                    Nombre = deposito.Nombre,
                    Direccion = deposito.Direccion,
                   
                });
            }

            return depositosDTO;
        }




        public DepositoDTO ObtenerDepositoPorId(int idDeposito)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            var deposito = depositoRepository.GetDepositoPorId(idDeposito);

            if (deposito == null)
            {
                throw new Exception($"No se encontró el Depósito con Id {idDeposito}");
            }

            return new DepositoDTO
            {
                Id = deposito.Id,
                Capacidad = deposito.Capacidad,
                Nombre = deposito.Nombre,
                Direccion = deposito.Direccion,
              
            };
        }




        public DepositoDTO ObtenerDepositoPorNombre(string nombreDeposito)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            Deposito deposito = depositoRepository.GetDepositoPorNombre(nombreDeposito);
            if (deposito == null)
            {
                throw new Exception($"No se encontró el depósito con nombre {nombreDeposito}");
            }

            return new DepositoDTO
            {
                Id = deposito.Id,
                Capacidad = deposito.Capacidad,
                Nombre = deposito.Nombre,
                Direccion = deposito.Direccion
            };
        }
    }
}

