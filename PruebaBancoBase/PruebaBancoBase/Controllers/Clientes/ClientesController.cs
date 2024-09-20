using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Clientes;
using Microsoft.AspNetCore.Mvc;
using Negocio.Clientes;

namespace PruebaBancoBase.Controllers.Clientes
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        ClientesNegocio negocio = new();
        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerTodosClientes")]
        public Respuesta obtenerTodosClientes()
        {
            return negocio.obtenerTodos();
        }
        [HttpGet("ObtenerClientePorId/{idCliente}")]
        public Respuesta obtenerClientePorId(int idCliente)
        {
            return negocio.obtenerClientePorId(idCliente);
        }
        [HttpPost("CrearCliente")]
        public Respuesta crearCliente([FromBody] CrearCliente cliente)
        {
            return negocio.crearCliente(cliente);
        }
        [HttpPut("ActualizarCliente")]
        public Respuesta actualizarCliente([FromBody] ActualizarCliente cliente)
        {
            return negocio.actualizarCliente(cliente);
        }
        [HttpDelete("EliminarCliente/{idCliente}")]
        public Respuesta eliminarCliente(int idCliente)
        {
            return negocio.eliminarCliente(idCliente);
        }
    }
}
