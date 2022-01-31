
using System.ComponentModel.DataAnnotations;

namespace contrato.entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(4)]
        public string Apellido { get; set; }
        [Required]
        [Range(3, 6)]
        public int Estado { get; set; }
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "El formato del correo es inválido")]
        public string Correo { get; set; }
    }
}