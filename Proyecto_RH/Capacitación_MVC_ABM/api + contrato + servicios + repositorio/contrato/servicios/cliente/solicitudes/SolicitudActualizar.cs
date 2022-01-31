using System.ComponentModel.DataAnnotations;

namespace contrato.servicios.cliente.solicitudes
{
    public class SolicitudActualizar
    {

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(4, ErrorMessage = "El nombre debe tener al menos 4 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(4, ErrorMessage = "El apellido debe tener al menos 4 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        [Range(3, 6, ErrorMessage = "El estado debe ser entre 3 y 6")]
        public int Estado { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "El formato del correo es inválido")]
        public string Correo { get; set; }
    }
}