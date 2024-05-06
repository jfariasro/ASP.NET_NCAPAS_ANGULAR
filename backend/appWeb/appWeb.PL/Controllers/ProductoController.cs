using appWeb.BLL.Services.Contracts;
using appWeb.Models;
using appWeb.PL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace appWeb.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> ObtenerTodo()
        {
            var productoSQL = await _service.ObtenerTodo();
            List<ProductoVM> listado = productoSQL.Select(p => new ProductoVM()
            {
                Idproducto = p.Idproducto,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Cantidad = p.Cantidad.ToString(),
                Precio = p.Precio.ToString()
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, listado);
        }

        [HttpGet]
        [Route("Buscar/{id:int}")]
        public async Task<IActionResult> Buscar([FromRoute] int id)
        {
            try
            {
                var producto = await _service.Buscar(id);

                return (producto == null) ? NotFound() :
                    StatusCode(StatusCodes.Status200OK, producto);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: "+ ex.Message);
            }
        }

        [HttpGet]
        [Route("Obtener/{nombreProducto}")]
        public async Task<IActionResult> ObtenerPorNombre([FromRoute] string nombreProducto)
        {
            var producto = await _service.ObtenerPorNombre(nombreProducto);

            return StatusCode(StatusCodes.Status200OK, producto);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] ProductoVM model)
        {
            try
            {
                Producto producto = new Producto()
                {
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Cantidad = int.Parse(model.Cantidad),
                    Precio = decimal.Parse(model.Precio)
                };

                var respuesta = await _service.Registrar(producto);

                return (respuesta) ?
                        StatusCode(StatusCodes.Status200OK, new { valor = respuesta }) : BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Modificar/{id:int}")]
        public async Task<IActionResult> Modificar([FromRoute] int id,[FromBody] ProductoVM model)
        {
            try
            {
                Producto producto = new Producto()
                {
                    Idproducto = id,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Cantidad = int.Parse(model.Cantidad),
                    Precio = decimal.Parse(model.Precio)
                };

                var respuesta = await _service.Modificar(id, producto);

                return (respuesta) ?
                    StatusCode(StatusCodes.Status200OK, new { valor = respuesta }) : BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                var respuesta = await _service.Eliminar(id);

                return (respuesta) ?
                    StatusCode(StatusCodes.Status200OK, new { valor = respuesta }) : BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
