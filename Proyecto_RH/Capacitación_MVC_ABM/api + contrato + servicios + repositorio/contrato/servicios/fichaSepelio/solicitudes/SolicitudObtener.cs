using System;

namespace contrato.servicios.fichaSepelio.solicitudes
{
    public class SolicitudObtener
    {
        public string NombreExtinto { get; set; }
        public string ApellidoExtinto { get; set; }
        public DateTime? FechaFallecimiento {get; set;}
    }
}
