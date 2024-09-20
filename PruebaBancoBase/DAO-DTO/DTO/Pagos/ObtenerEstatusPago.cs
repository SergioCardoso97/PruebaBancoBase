using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_DTO.DTO.Pagos
{
    public class ObtenerEstatusPago
    {
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }
        public int IdVendedor { get; set; }
        public string Vendedor { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Concepto { get; set; }
        public double MontoTotal { get; set; }
    }
}
