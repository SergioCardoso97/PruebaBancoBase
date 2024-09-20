using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_DTO.DAO.Pagos
{
    public class CrearPago
    {
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public int IdOrden { get; set; }
        public string Concepto { get; set; }
    }
}
