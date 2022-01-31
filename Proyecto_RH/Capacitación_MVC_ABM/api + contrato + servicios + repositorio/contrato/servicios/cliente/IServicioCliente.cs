using System.Threading.Tasks;
using contrato.servicios.cliente.solicitudes;

namespace contrato.servicios.cliente
{
    public interface IServicioCliente
    {
        Task<respuestas.RespuestaObtener> Obtener(solicitudes.SolicitudObtener solicitud);
        Task<respuestas.RespuestaCrear> Crear(solicitudes.SolicitudCrear solicitud);
        Task<respuestas.RespuestaEliminar> Eliminar(int id);
        Task<respuestas.RespuestaActualizar> Actualizar(int id, solicitudes.SolicitudActualizar solicitud);

    }
}

