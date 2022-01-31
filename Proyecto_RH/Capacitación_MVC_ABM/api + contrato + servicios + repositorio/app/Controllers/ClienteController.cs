using System.Threading.Tasks;
using contrato.entidades;
using contrato.servicios.cliente;
using contrato.servicios.cliente.solicitudes;
using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly IServicioCliente _servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SolicitudObtener solicitud)
        {
            var clientes = await _servicioCliente.Obtener(solicitud);
            return Ok(clientes.Clientes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clientes = await _servicioCliente.Eliminar(id);
            return Ok(clientes.Clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SolicitudCrear solicitud)
        {
            var respuesta_crear = await _servicioCliente.Crear(solicitud);
            return Ok(respuesta_crear);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar([FromRoute] int id, [FromBody] SolicitudActualizar solicitud)
        {
            var respuesta_actualizar = await _servicioCliente.Actualizar(id, solicitud);

            if (respuesta_actualizar == null)
            {
                return NotFound("Error: Usuario no encontrado");
            }
            return Ok(respuesta_actualizar);
        }
    }



}