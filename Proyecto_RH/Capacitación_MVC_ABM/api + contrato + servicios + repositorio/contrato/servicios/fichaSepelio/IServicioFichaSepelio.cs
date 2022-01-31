using System.Threading.Tasks;
using contrato.servicios.fichaSepelio.solicitudes;

namespace contrato.servicios.fichaSepelio
{
    public interface IServicioFichaSepelio
    {
        Task<respuestas.RespuestaObtener> Obtener(solicitudes.SolicitudObtener solicitud);
        Task<respuestas.RespuestaCrear> Crear(solicitudes.SolicitudCrear solicitud);
        Task<respuestas.RespuestaEliminar> Eliminar(int id);
        Task<respuestas.RespuestaActualizar> Actualizar(solicitudes.SolicitudActualizar solicitud);

    }
}