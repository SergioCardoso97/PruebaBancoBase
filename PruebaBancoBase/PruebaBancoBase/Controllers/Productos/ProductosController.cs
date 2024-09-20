using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Productos;
using Microsoft.AspNetCore.Mvc;
using Negocio.Productos;

namespace PruebaBancoBase.Controllers.Productos
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        ProductosNegocio negocio = new();
        private readonly ILogger<ProductosController> _logger;
        public ProductosController(ILogger<ProductosController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ObtenerTodosProductos")]
        public Respuesta obtenerTodosProductos()
        {
            return negocio.obtenerTodos();
        }
        [HttpGet("ObtenerProductoPorId/{idProducto}")]
        public Respuesta obtenerProductoePorId(int idProducto)
        {
            return negocio.obtenerProductoPorId(idProducto);
        }
        [HttpPost("CrearProducto")]
        public Respuesta crearProducto([FromBody] CrearProducto Producto)
        {
            return negocio.crearProducto(Producto);
        }
        [HttpPut("ActualizarProducto")]
        public Respuesta actualizarProducto([FromBody] ActualizarProducto Producto)
        {
            return negocio.actualizarProducto(Producto);
        }
        [HttpDelete("EliminarProducto/{idProducto}")]
        public Respuesta eliminarProducto(int idProducto)
        {
            return negocio.eliminarProducto(idProducto);
        }
    }
}
