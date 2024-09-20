using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_DTO.DAO.Ordenes
{
    public class ActualizarOrden
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public List<CrearRelacionOrdenProductos> ordenProductos { get; set; }
    }
}
