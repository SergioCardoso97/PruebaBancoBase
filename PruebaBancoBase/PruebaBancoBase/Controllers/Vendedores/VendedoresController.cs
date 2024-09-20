using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Vendedores;
using Microsoft.AspNetCore.Mvc;
using Negocio.Vendedores;
using Negocio.Vendedores;
using PruebaBancoBase.Controllers.Vendedores;

namespace PruebaBancoBase.Controllers.Vendedores
{
    [ApiController]
    [Route("[controller]")]
    public class VendedoresController : ControllerBase
    {
        VendedoresNegocio negocio = new();
        private readonly ILogger<VendedoresController> _logger;
        public VendedoresController(ILogger<VendedoresController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerTodosVendedores")]
        public Respuesta obtenerTodosVendedores()
        {
            return negocio.obtenerTodos();
        }
        [HttpGet("ObtenerVendedorPorId/{idVendedor}")]
        public Respuesta obtenerVendedorePorId(int idVendedor)
        {
            return negocio.obtenerVendedorPorId(idVendedor);
        }
        [HttpPost("CrearVendedor")]
        public Respuesta crearVendedor([FromBody] CrearVendedor Vendedor)
        {
            return negocio.crearVendedor(Vendedor);
        }
        [HttpPut("ActualizarVendedor")]
        public Respuesta actualizarVendedor([FromBody] ActualizarVendedor Vendedor)
        {
            return negocio.actualizarVendedor(Vendedor);
        }
        [HttpDelete("EliminarVendedor/{idVendedor}")]
        public Respuesta eliminarVendedor(int idVendedor)
        {
            return negocio.eliminarVendedor(idVendedor);
        }
    }
}
