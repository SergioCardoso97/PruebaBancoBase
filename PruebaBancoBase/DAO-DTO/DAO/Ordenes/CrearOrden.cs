using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_DTO.DAO.Ordenes
{
    public class CrearOrden
    {
        public int IdCliente { get; set; }
        public List<CrearRelacionOrdenProductos> ordenProductos { get; set; }
    }
    public class CrearRelacionOrdenProductos
    {
        public int IdProducto { get; set; }
    }
}
