using AutoMapper;
using CodigoComun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelos.DTO
{
    public class DepositoDTO : BaseDTO
    {

        public int Id { get; set; }
        public decimal? Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Deposito GetDeposito (DepositoDTO depositoDTO)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepositoDTO, Deposito>());
            var mapper = new Mapper(config);

            Deposito depositoADevolver = mapper.Map<Deposito>(depositoDTO);
            return depositoADevolver;

        }
    }
}
