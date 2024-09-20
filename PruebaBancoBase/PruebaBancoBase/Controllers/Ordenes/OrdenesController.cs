using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Ordenes;
using Microsoft.AspNetCore.Mvc;
using Negocio.Ordenes;

namespace PruebaBancoBase.Controllers.Ordenes
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenesController : ControllerBase
    {
        OrdenesNegocio negocio = new();
        private readonly ILogger<OrdenesController> _logger;
        public OrdenesController(ILogger<OrdenesController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerTodosOrdenes")]
        public Respuesta obtenerTodosOrdenes()
        {
            return negocio.obtenerTodos();
        }
        [HttpGet("ObtenerOrdenPorId/{idOrden}")]
        public Respuesta obtenerOrdenePorId(int idOrden)
        {
            return negocio.obtenerOrdenPorId(idOrden);
        }
        [HttpGet("ObtenerOrdenesPorCliente/{idCliente}")]
        public Respuesta obtenerOrdenesPorCliente(int idCliente)
        {
            return negocio.obtenerOrdenesPorCliente(idCliente);
        }
        [HttpPost("CrearOrden")]
        public Respuesta crearOrden([FromBody] CrearOrden Orden)
        {
            return negocio.crearOrden(Orden);
        }
        [HttpPut("ActualizarOrden")]
        public Respuesta actualizarOrden([FromBody] ActualizarOrden Orden)
        {
            return negocio.actualizarOrden(Orden);
        }
        [HttpDelete("EliminarOrden/{idOrden}")]
        public Respuesta eliminarOrden(int idOrden)
        {
            return negocio.eliminarOrden(idOrden);
        }
    }
}
