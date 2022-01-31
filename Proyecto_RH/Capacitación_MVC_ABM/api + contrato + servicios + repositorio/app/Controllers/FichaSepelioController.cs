using System.Threading.Tasks;
using contrato.entidades;
using contrato.servicios.fichaSepelio;
using contrato.servicios.fichaSepelio.solicitudes;
using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class FichaSepelioController : Controller
    {
        private readonly IServicioFichaSepelio _servicioFichaSepelio;

        public FichaSepelioController(IServicioFichaSepelio servicioFichaSepelio)
        {
            _servicioFichaSepelio = servicioFichaSepelio;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SolicitudObtener solicitud)
        {
            var fichas = await _servicioFichaSepelio.Obtener(solicitud);
            return Ok(fichas);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var fichas = await _servicioFichaSepelio.Eliminar(id);
            if (fichas == null)
            {
                return NotFound("Error: Ficha no encontrada.");
            }else{
               return Ok(fichas.Fichas); 
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] SolicitudCrear solicitud)
        {
            var respuesta_crear = await _servicioFichaSepelio.Crear(solicitud);
            return Ok(respuesta_crear);
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromQuery]SolicitudActualizar solicitud)
        {
            var respuesta_actualizar = await _servicioFichaSepelio.Actualizar(solicitud);

            // if (respuesta_actualizar == null)
            // {
            //     return NotFound("Error: Ficha no encontrada.");
            // }else {
            return Ok(respuesta_actualizar);
            // }
            
        }
    }



}