using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploController : ControllerBase
    {
        private readonly ILogger<EjemploController> _logger;

        public EjemploController(ILogger<EjemploController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ObtenerDatos()
        {
            _logger.LogInformation("Se ha llamado al método ObtenerDatos.");

            try
            {
                var datos = ObtenerDatosEjemplo();
                _logger.LogInformation("Datos obtenidos correctamente.");

                return Ok(new { Mensaje = "Datos obtenidos correctamente.", Datos = datos });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener datos: {ex.Message}");
                return StatusCode(500, new { Mensaje = "Error interno del servidor." });
            }
        }

        private List<Ejemplo> ObtenerDatosEjemplo()
        {
            // Lógica para obtener datos 
            return new List<Ejemplo>
            {
                new Ejemplo { Id = 1, Nombre = "Elemento 1" },
                new Ejemplo { Id = 2, Nombre = "Elemento 2" },
                new Ejemplo { Id = 3, Nombre = "Elemento 3" }
            };
        }
    }
}
