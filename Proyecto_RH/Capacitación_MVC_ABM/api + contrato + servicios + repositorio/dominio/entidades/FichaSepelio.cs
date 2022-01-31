using dominio.infraestructura;
using System;

namespace dominio.entidades
{
    public class FichaSepelio : EntidadBase
    {
        public string NombreExtinto { get; set; }
        public string ApellidoExtinto { get; set; }
        public int DNIExtinto {get; set;}
        public DateTime FechaNacimientoExtinto {get; set;}
        public int EdadExtinto {get; set;}
        public string EstadoCivil {get; set;}
        public string Doctor {get; set;}
        public string Barrio {get; set;}
        public string CasaDeDuelo {get; set;}
        public float GastoDoctor {get; set;}
        public string Clinica {get; set;}
        public DateTime FechaFallecimiento { get; set; }
        public string HoraFallecimiento {get; set;}
        public string LugarDeFallecimiento {get; set;}
        public string Hora {get; set;}
        public string Servicio {get; set;}
        public string Iglesia {get; set;}
        public string Nota{get; set;}
        public string TipoAtaud {get; set;}
        public string Cementerio {get; set;}
        public string Sector {get; set;}
        public int Numero {get; set;}
        public string NombreFamiliar {get; set;}
        public string ApellidoFamiliar {get; set;}
        public int DNIFamiliar {get; set;}
        public string TitularFacturacion {get; set;}
        public string TelefonoFamiliar {get; set;}
        public string EmailFamiliar {get; set;}
        public string DomicilioFamiliar {get; set;}
        public string NotaFamiliar {get; set;}
        public float GastosDiarios {get; set;}
        public float GastosIglesia {get; set;}
        public float GastosRadio {get; set;}
        public float GastosMunicipalidad {get; set;}
        public float GastosTranslado {get; set;}
        public float GastosReduccion {get; set;}
        public float GastosReinscripcion {get; set;}
        public string GastosNombreDoctor {get; set;}
        public float GastosDoctor {get; set;}
        public float GastosEscribano{get; set;}
        public float GastosTraslado2 {get; set;}
        public float GastosCremacion {get; set;}
        public float GastosFlores {get; set;}
        public float TotalCtaCte {get; set;}
        public float TotalContado {get; set;}
        public DateTime FechaC {get; set;}
        public DateTime FechaA {get; set;}
        public DateTime FechaI {get; set;}
        
    }
}