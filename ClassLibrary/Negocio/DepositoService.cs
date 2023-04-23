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

        public List<Deposito> ObtenerTodosLosDepositos()
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            return depositoRepository.GetTodosLosDepositos();
        }

        public string EliminarDeposito(int idDepositoEliminar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            int resultado = depositoRepository.EliminarDeposito(idDepositoEliminar);

            if (resultado == 1)
            {
                return "Depósito eliminado correctamente";
            }
            else
            {
                return "Error al eliminar el depósito";
            }
        }

        public Deposito ObtenerDepositoPorId(int idDeposito)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            return depositoRepository.GetDepositoPorId(idDeposito);
        }

        public DepositoDTO AgregarDeposito(DepositoDTO depositoDTOAAgregar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
           
            
            try
            {
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



        public Deposito ObtenerDepositoPorNombre(string nombreDeposito)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            return depositoRepository.GetDepositoPorNombre(nombreDeposito);
        }



        public int ModificarDeposito(Deposito depositoAModificar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();
            int resultado = depositoRepository.ActualizarDeposito(depositoAModificar);

            if (resultado == 1)
            {
                return resultado;
            }
            else
            {
                return -1;
            }
        }

    }
}

