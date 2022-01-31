using dominio.infraestructura;

namespace dominio.entidades
{
    public class Cliente : EntidadBase
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Correo { get; set; }
        public virtual int Estado { get; set; }
    }
}
