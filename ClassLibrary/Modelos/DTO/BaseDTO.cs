using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelos.DTO
{
    public class BaseDTO
    {

        public string Mensaje { get; set; }

        public bool HuboError { get; set; }

        public string Origen { get; set; }
    }
}
