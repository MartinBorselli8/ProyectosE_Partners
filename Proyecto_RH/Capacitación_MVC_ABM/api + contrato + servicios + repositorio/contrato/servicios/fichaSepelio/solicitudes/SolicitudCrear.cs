using System.ComponentModel.DataAnnotations;
using System;

namespace contrato.servicios.fichaSepelio.solicitudes
{
    public class SolicitudCrear
    {
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string NombreExtinto { get; set; }
      //  [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string ApellidoExtinto { get; set; }
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int DNIExtinto {get; set;}

      //  [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime FechaNacimientoExtinto {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public int EdadExtinto {get; set;}
      //  [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string EstadoCivil {get; set;}
      //  [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Doctor {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Barrio {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public string CasaDeDuelo {get; set;}
        // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public float GastoDoctor {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Clinica {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime FechaFallecimiento { get; set; }
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string HoraFallecimiento {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string LugarDeFallecimiento {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Hora {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Servicio {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Iglesia {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nota{get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string TipoAtaud {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Cementerio {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Sector {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Numero {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string NombreFamiliar {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public string ApellidoFamiliar {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int DNIFamiliar {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string TitularFacturacion {get; set;}
      //  [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string TelefonoFamiliar {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
       // [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "El formato del correo es inválido")]
        public string EmailFamiliar {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public string DomicilioFamiliar {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public string NotaFamiliar {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosDiarios {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosIglesia {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosRadio {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosMunicipalidad {get; set;}
      //  [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosTraslado {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosReduccion {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosReinscripcion {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public string GastosNombreDoctor {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosDoctor {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosEscribano{get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosTraslado2 {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosCremacion {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float GastosFlores {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float TotalCtaCte {get; set;}
       // [Required(ErrorMessage = "Este campo es obligatorio.")] 
        public float TotalContado {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public DateTime FechaC {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public DateTime FechaA {get; set;}
        //[Required(ErrorMessage = "Este campo es obligatorio.")] 
        public DateTime FechaI {get; set;}


    }
}