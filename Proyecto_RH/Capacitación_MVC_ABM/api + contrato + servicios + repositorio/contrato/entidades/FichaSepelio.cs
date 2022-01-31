using System;
using System.ComponentModel.DataAnnotations;

namespace contrato.entidades
{
    public class FichaSepelio
    {
        // [Required]
        // [MinLength(3)]
        public string NombreExtinto { get; set; }
        // [Required]
        // [MinLength(3)]
        public string ApellidoExtinto { get; set; }
        // [Required]
        public int DNIExtinto {get; set;}

        // [Required]
        public DateTime FechaNacimientoExtinto {get; set;}
        // [Required]
        public int EdadExtinto {get; set;}
        // [Required]
        public string EstadoCivil {get; set;}
        // [Required]
        public string Doctor {get; set;}
        // [Required]
        public string Barrio {get; set;}
        // [Required] 
        public string CasaDeDuelo {get; set;}
        // [Required]
        public float GastoDoctor {get; set;}
        // [Required]
        public string Clinica {get; set;}
        // [Required]
        public DateTime FechaFallecimiento { get; set; }
        // [Required]
        public string HoraFallecimiento {get; set;}
        // [Required]
        public string LugarDeFallecimiento {get; set;}
        // [Required]
        public string Hora {get; set;}
        // [Required]
        public string Servicio {get; set;}
        // [Required]
        public string Iglesia {get; set;}
        // [Required]
        public string Nota{get; set;}
        // [Required]
        public string TipoAtaud {get; set;}
        // [Required]
        public string Cementerio {get; set;}
        // [Required]
        public string Sector {get; set;}
        // [Required]
        public int Numero {get; set;}
        // [Required]
        public string NombreFamiliar {get; set;}
        // [Required]
        public string ApellidoFamiliar {get; set;}
        // [Required]
        public int DNIFamiliar {get; set;}
        // [Required]
        public string TitularFacturacion {get; set;}
        // [Required]
        public string TelefonoFamiliar {get; set;}
        // [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "El formato del correo es inválido")]
        public string EmailFamiliar {get; set;}
        // [Required] 
        public string DomicilioFamiliar {get; set;}
        // [Required] 
        public string NotaFamiliar {get; set;}
        // [Required] 
        public float GastosDiarios {get; set;}
        // [Required] 
        public float GastosIglesia {get; set;}
        // [Required] 
        public float GastosRadio {get; set;}
        // [Required] 
        public float GastosMunicipalidad {get; set;}
        // [Required] 
        public float GastosTranslado {get; set;}
        // [Required] 
        public float GastosReduccion {get; set;}
        // [Required] 
        public float GastosReinscripcion {get; set;}
        // [Required] 
        public string GastosNombreDoctor {get; set;}
        // [Required] 
        public float GastosDoctor {get; set;}
        // [Required] 
        public float GastosEscribano{get; set;}
        // [Required] 
        public float GastosTraslado2 {get; set;}
        // [Required] 
        public float GastosCremacion {get; set;}
        // [Required] 
        public float GastosFlores {get; set;}
        // [Required] 
        public float TotalCtaCte {get; set;}
        // [Required] 
        public float TotalContado {get; set;}
        // [Required] 
        public DateTime FechaC {get; set;}
        // [Required] 
        public DateTime FechaA {get; set;}
        // [Required] 
        public DateTime FechaI {get; set;}
    }
}