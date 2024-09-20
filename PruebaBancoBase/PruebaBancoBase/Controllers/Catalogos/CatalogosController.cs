using Acceso_Datos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Catalogos;

namespace PruebaBancoBase.Controllers.Catalogos
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogosController : ControllerBase
    {
        private readonly ILogger<CatalogosController> _logger;
        CatalogosNegocio negocio = new();
        public CatalogosController(ILogger<CatalogosController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerEstatusPago")]
        public Respuesta obtenerEstatus()
        {
            return negocio.obtenerCatalogoEstatusPago();
        }
    }
}
