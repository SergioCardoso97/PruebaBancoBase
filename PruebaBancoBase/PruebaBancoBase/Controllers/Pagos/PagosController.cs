using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Pagos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Pagos;

namespace PruebaBancoBase.Controllers.Pagos
{
    [ApiController]
    [Route("[controller]")]
    public class PagosController : ControllerBase
    {
        PagosNegocio negocio = new();
        private readonly ILogger<PagosController> _logger;
        public PagosController(ILogger<PagosController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerEstatusPagoPorId/{idPago}")]
        public Respuesta obtenerEstatusPagoPorId(int idPago)
        {
            return negocio.obtenerEstatusPorId(idPago);
        }
        [HttpGet("CambiarEstatusPagoPorId/{idPago}/{idEstatus}")]
        public Respuesta cambiarEstatusPagoPorId(int idPago, int idEstatus)
        {
            return negocio.cambiarEstatusPago(idPago, idEstatus);
        }
        [HttpPost("CrearPago")]
        public Respuesta crearPago([FromBody] CrearPago pago)
        {
            return negocio.crearPago(pago);
        }
    }
}
