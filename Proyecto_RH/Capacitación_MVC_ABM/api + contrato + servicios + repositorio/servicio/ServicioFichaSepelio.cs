using contrato.servicios.fichaSepelio;
using contrato.entidades;
using contrato.servicios.fichaSepelio.respuestas;
using contrato.servicios.fichaSepelio.solicitudes;
using System.Threading.Tasks;
using System.Linq;
using dominio.infraestructura;
using System.Linq.Expressions;
using System;
using dominio;
using System.Collections.Generic;

namespace servicio
{
    public class ServicioFichaSepelio : IServicioFichaSepelio
    {
        private readonly IRepositorio<dominio.entidades.FichaSepelio> _repositorioFichaSepelio;

        public ServicioFichaSepelio(IRepositorio<dominio.entidades.FichaSepelio> repositorioFichaSepelio)
        {
            this._repositorioFichaSepelio = repositorioFichaSepelio;
        }
        
        public async Task<RespuestaCrear> Crear(SolicitudCrear solicitud)
        {
            var respuesta = new RespuestaCrear();
            var fichaNueva = FichaMapeada(solicitud);
            await _repositorioFichaSepelio.Crear(fichaNueva);
            respuesta.Id = fichaNueva.Id;
            return respuesta;
        }

        public async Task<RespuestaEliminar> Eliminar(int id)
        {
            var respuesta = new RespuestaEliminar();
            var fichaAEliminar = await _repositorioFichaSepelio.Buscar(c => c.Id == id);
            if(fichaAEliminar.Count() >0){
                await _repositorioFichaSepelio.Eliminar(fichaAEliminar[0]);
                var todasLasFichas = await _repositorioFichaSepelio.BuscarTodos();
                respuesta.Fichas = ListaMapeada(todasLasFichas);
                return respuesta;
            }else{
                return null;
            }
            
            
        }

        private List<contrato.entidades.FichaSepelio> ListaMapeada(List<dominio.entidades.FichaSepelio> todasLasFichas)
        {
            var lista = new List<contrato.entidades.FichaSepelio>(); 
            lista=todasLasFichas.Select(c => new FichaSepelio()
                {
                    NombreExtinto = c.NombreExtinto,
                    ApellidoExtinto = c.ApellidoExtinto,
                    DNIExtinto = c.DNIExtinto,
                    FechaNacimientoExtinto = c.FechaNacimientoExtinto,
                    EdadExtinto=c.EdadExtinto,
                    EstadoCivil = c.EstadoCivil,
                    Doctor = c.Doctor,
                    Barrio= c.Barrio,
                    CasaDeDuelo=c.CasaDeDuelo,
                    GastoDoctor=c.GastoDoctor,
                    Clinica=c.Clinica,
                    FechaFallecimiento = c.FechaFallecimiento,
                    HoraFallecimiento=c.HoraFallecimiento,
                    LugarDeFallecimiento=c.LugarDeFallecimiento,
                    Hora=c.Hora,
                    Servicio=c.Servicio,
                    Iglesia=c.Iglesia,
                    Nota=c.Nota,
                    TipoAtaud=c.TipoAtaud,
                    Cementerio=c.Cementerio,
                    Sector=c.Sector,
                    Numero=c.Numero,
                    NombreFamiliar=c.NombreFamiliar,
                    ApellidoFamiliar=c.ApellidoFamiliar,
                    DNIFamiliar=c.DNIFamiliar,
                    TitularFacturacion=c.TitularFacturacion,
                    TelefonoFamiliar=c.TelefonoFamiliar,
                    EmailFamiliar=c.EmailFamiliar,
                    DomicilioFamiliar=c.DomicilioFamiliar,
                    NotaFamiliar=c.NotaFamiliar,
                    GastosDiarios=c.GastosDiarios,
                    GastosIglesia=c.GastosIglesia,
                    GastosRadio=c.GastosRadio,
                    GastosMunicipalidad=c.GastosMunicipalidad,
                    GastosTraslado=c.GastosTraslado,
                    GastosReduccion=c.GastosReduccion,
                    GastosReinscripcion=c.GastosReinscripcion,
                    GastosNombreDoctor=c.GastosNombreDoctor,
                    GastosDoctor=c.GastoDoctor,
                    GastosEscribano=c.GastosEscribano,
                    GastosTraslado2=c.GastosTraslado2,
                    GastosCremacion=c.GastosCremacion,
                    GastosFlores=c.GastosFlores,
                    TotalCtaCte=c.TotalCtaCte,
                    TotalContado=c.TotalContado,
                    FechaC=c.FechaC,
                    FechaA=c.FechaA,
                    FechaI=c.FechaI
                }).ToList();

                return lista;
        }

        public async Task<RespuestaObtener> Obtener(SolicitudObtener solicitud)
        {
            var respuesta = new RespuestaObtener();
            var predicado = ArmarPredicado(solicitud);
            var respuesta_servicio = await _repositorioFichaSepelio.Buscar(predicado);
            respuesta.Fichas = respuesta_servicio.Select(c => new FichaSepelio()
            {
                Id= c.Id,
                NombreExtinto = c.NombreExtinto,
                ApellidoExtinto = c.ApellidoExtinto,
                DNIExtinto = c.DNIExtinto,
                FechaNacimientoExtinto = c.FechaNacimientoExtinto,
                EdadExtinto=c.EdadExtinto,
                EstadoCivil = c.EstadoCivil,                    
                Doctor = c.Doctor,
                Barrio= c.Barrio,
                CasaDeDuelo=c.CasaDeDuelo,
                GastoDoctor=c.GastoDoctor,
                Clinica=c.Clinica,
                FechaFallecimiento = c.FechaFallecimiento,
                HoraFallecimiento=c.HoraFallecimiento,
                LugarDeFallecimiento=c.LugarDeFallecimiento,
                Hora=c.Hora,
                Servicio=c.Servicio,
                Iglesia=c.Iglesia,
                Nota=c.Nota,
                TipoAtaud=c.TipoAtaud,
                Cementerio=c.Cementerio,
                Sector=c.Sector,
                Numero=c.Numero,
                NombreFamiliar=c.NombreFamiliar,
                ApellidoFamiliar=c.ApellidoFamiliar,
                DNIFamiliar=c.DNIFamiliar,
                TitularFacturacion=c.TitularFacturacion,
                TelefonoFamiliar=c.TelefonoFamiliar,
                EmailFamiliar=c.EmailFamiliar,
                DomicilioFamiliar=c.DomicilioFamiliar,
                NotaFamiliar=c.NotaFamiliar,
                GastosDiarios=c.GastosDiarios,
                GastosIglesia=c.GastosIglesia,
                GastosRadio=c.GastosRadio,
                GastosMunicipalidad=c.GastosMunicipalidad,
                GastosTraslado=c.GastosTraslado,
                GastosReduccion=c.GastosReduccion,
                GastosReinscripcion=c.GastosReinscripcion,
                GastosNombreDoctor=c.GastosNombreDoctor,
                GastosDoctor=c.GastosDoctor,
                GastosEscribano=c.GastosEscribano,
                GastosTraslado2=c.GastosTraslado2,
                GastosCremacion=c.GastosCremacion,
                GastosFlores=c.GastosFlores,
                TotalCtaCte=c.TotalCtaCte,
                TotalContado=c.TotalContado,
                FechaC=c.FechaC,
                FechaA=c.FechaA,
                FechaI=c.FechaI
            }).ToList();
            return respuesta;
        }



        private Expression<Func<dominio.entidades.FichaSepelio, bool>> ArmarPredicado(SolicitudObtener solicitud)
        {
            var predicado = CrearPredicado.Verdadero<dominio.entidades.FichaSepelio>();
            if (!string.IsNullOrEmpty(solicitud.ApellidoExtinto)) predicado = predicado.Y(c => c.ApellidoExtinto.ToLower().Contains(solicitud.ApellidoExtinto.ToLower()));
            if (!string.IsNullOrEmpty(solicitud.NombreExtinto)) predicado = predicado.Y(c => c.NombreExtinto.ToLower().Contains(solicitud.NombreExtinto.ToLower()));
            if (solicitud.FechaFallecimiento != null) predicado = predicado.Y(c => c.FechaFallecimiento == solicitud.FechaFallecimiento); 
            return predicado;
        }

        private dominio.entidades.FichaSepelio FichaMapeada(SolicitudCrear solicitud)
        {
            var ficha = new dominio.entidades.FichaSepelio();
            ficha.NombreExtinto = solicitud.NombreExtinto;
            ficha.ApellidoExtinto = solicitud.ApellidoExtinto;
            ficha.DNIExtinto = solicitud.DNIExtinto;
            ficha.FechaNacimientoExtinto = solicitud.FechaNacimientoExtinto;
            ficha.EdadExtinto=solicitud.EdadExtinto;
            ficha.EstadoCivil = solicitud.EstadoCivil;
            ficha.Doctor = solicitud.Doctor;
            ficha.Barrio= solicitud.Barrio;
            ficha.CasaDeDuelo=solicitud.CasaDeDuelo;
            ficha.GastoDoctor=solicitud.GastoDoctor;
            ficha.Clinica=solicitud.Clinica;
            ficha.FechaFallecimiento = solicitud.FechaFallecimiento;
            ficha.HoraFallecimiento=solicitud.HoraFallecimiento;
            ficha.LugarDeFallecimiento=solicitud.LugarDeFallecimiento;
            ficha.Hora=solicitud.Hora;
            ficha.Servicio=solicitud.Servicio;
            ficha.Iglesia=solicitud.Iglesia;
            ficha.Nota=solicitud.Nota;
            ficha.TipoAtaud=solicitud.TipoAtaud;
            ficha.Cementerio=solicitud.Cementerio;
            ficha.Sector=solicitud.Sector;
            ficha.Numero=solicitud.Numero;
            ficha.NombreFamiliar=solicitud.NombreFamiliar;
            ficha.ApellidoFamiliar=solicitud.ApellidoFamiliar;
            ficha.DNIFamiliar=solicitud.DNIFamiliar;
            ficha.TitularFacturacion=solicitud.TitularFacturacion;
            ficha.TelefonoFamiliar=solicitud.TelefonoFamiliar;
            ficha.EmailFamiliar=solicitud.EmailFamiliar;
            ficha.DomicilioFamiliar=solicitud.DomicilioFamiliar;
            ficha.NotaFamiliar=solicitud.NotaFamiliar;
            ficha.GastosDiarios=solicitud.GastosDiarios;
            ficha.GastosIglesia=solicitud.GastosIglesia;
            ficha.GastosRadio=solicitud.GastosRadio;
            ficha.GastosMunicipalidad=solicitud.GastosMunicipalidad;
            ficha.GastosTraslado=solicitud.GastosTraslado;
            ficha.GastosReduccion=solicitud.GastosReduccion;
            ficha.GastosReinscripcion=solicitud.GastosReinscripcion;
            ficha.GastosNombreDoctor=solicitud.GastosNombreDoctor;
            ficha.GastosDoctor=solicitud.GastosDoctor;
            ficha.GastosEscribano=solicitud.GastosEscribano;
            ficha.GastosTraslado2=solicitud.GastosTraslado2;
            ficha.GastosCremacion=solicitud.GastosCremacion;
            ficha.GastosFlores=solicitud.GastosFlores;
            ficha.TotalCtaCte=solicitud.TotalCtaCte;
            ficha.TotalContado=solicitud.TotalContado;
            ficha.FechaC=solicitud.FechaC;
            ficha.FechaA=solicitud.FechaA;
            ficha.FechaI=solicitud.FechaI;
            ficha.FechaNacimientoExtinto=solicitud.FechaNacimientoExtinto;
            
            return ficha;
        }

        public async Task<RespuestaActualizar> Actualizar(SolicitudActualizar solicitud)
        {
            var respuesta = new RespuestaActualizar();
            var ficha = await _repositorioFichaSepelio.Obtener(solicitud.id);
            if(ficha != null){
                ficha = MapearActualizarFicha(ficha, solicitud);
                await _repositorioFichaSepelio.Actualizar(ficha);
                var fichaNueva = await _repositorioFichaSepelio.Obtener(solicitud.id);
                respuesta.fichaSepelio = FichaNuevaRespuesta(fichaNueva);
                return respuesta;
            }else{
                return null;
            }
        }

        private dominio.entidades.FichaSepelio MapearActualizarFicha(dominio.entidades.FichaSepelio ficha, SolicitudActualizar solicitud)
        {

            if(!string.IsNullOrEmpty(solicitud.NombreExtinto)) ficha.NombreExtinto = solicitud.NombreExtinto;
            if(!string.IsNullOrEmpty(solicitud.ApellidoExtinto)) ficha.ApellidoExtinto = solicitud.ApellidoExtinto;
            if(solicitud.DNIExtinto > 0) ficha.DNIExtinto = solicitud.DNIExtinto;
            if(solicitud.FechaNacimientoExtinto != null) ficha.FechaNacimientoExtinto=Convert.ToDateTime(solicitud.FechaNacimientoExtinto);
            if(solicitud.EdadExtinto > 0) ficha.EdadExtinto = solicitud.EdadExtinto;
            if(!string.IsNullOrEmpty(solicitud.EstadoCivil)) ficha.EstadoCivil = solicitud.EstadoCivil;
            if(!string.IsNullOrEmpty(solicitud.Doctor)) ficha.Doctor = solicitud.Doctor;
            if(!string.IsNullOrEmpty(solicitud.Barrio)) ficha.Barrio = solicitud.Barrio;
            if(!string.IsNullOrEmpty(solicitud.CasaDeDuelo)) ficha.CasaDeDuelo = solicitud.CasaDeDuelo;
            if(solicitud.GastoDoctor > 0) ficha.GastoDoctor = solicitud.GastoDoctor;
            if(!string.IsNullOrEmpty(solicitud.Clinica)) ficha.Clinica = solicitud.Clinica;
            if(solicitud.FechaFallecimiento != null) ficha.FechaFallecimiento = Convert.ToDateTime(solicitud.FechaFallecimiento);
            if(!string.IsNullOrEmpty(solicitud.HoraFallecimiento)) ficha.HoraFallecimiento = solicitud.HoraFallecimiento;
            if(!string.IsNullOrEmpty(solicitud.LugarDeFallecimiento)) ficha.LugarDeFallecimiento = solicitud.LugarDeFallecimiento;
            if(!string.IsNullOrEmpty(solicitud.Hora)) ficha.Hora = solicitud.Hora;
            if(!string.IsNullOrEmpty(solicitud.Servicio)) ficha.Servicio = solicitud.Servicio;
            if(!string.IsNullOrEmpty(solicitud.Iglesia)) ficha.Iglesia = solicitud.Iglesia;
            if(!string.IsNullOrEmpty(solicitud.Nota)) ficha.Nota = solicitud.Nota;
            if(!string.IsNullOrEmpty(solicitud.TipoAtaud)) ficha.TipoAtaud = solicitud.TipoAtaud;
            if(!string.IsNullOrEmpty(solicitud.Cementerio)) ficha.Cementerio = solicitud.Cementerio;
            if(!string.IsNullOrEmpty(solicitud.Sector)) ficha.Sector = solicitud.Sector;
            if(solicitud.Numero > 0) ficha.Numero = solicitud.Numero;
            if(!string.IsNullOrEmpty(solicitud.NombreFamiliar)) ficha.NombreFamiliar = solicitud.NombreFamiliar;
            if(!string.IsNullOrEmpty(solicitud.ApellidoFamiliar)) ficha.ApellidoFamiliar = solicitud.ApellidoFamiliar;
            if(!string.IsNullOrEmpty(solicitud.Cementerio)) ficha.Cementerio = solicitud.Cementerio;
            if(solicitud.DNIFamiliar > 0) ficha.DNIFamiliar = solicitud.DNIFamiliar;
            if(!string.IsNullOrEmpty(solicitud.TitularFacturacion)) ficha.TitularFacturacion = solicitud.TitularFacturacion;
            if(!string.IsNullOrEmpty(solicitud.TelefonoFamiliar)) ficha.TelefonoFamiliar = solicitud.TelefonoFamiliar;
            if(!string.IsNullOrEmpty(solicitud.EmailFamiliar)) ficha.EmailFamiliar = solicitud.EmailFamiliar;
            if(!string.IsNullOrEmpty(solicitud.DomicilioFamiliar)) ficha.DomicilioFamiliar = solicitud.DomicilioFamiliar;
            if(!string.IsNullOrEmpty(solicitud.NotaFamiliar)) ficha.NotaFamiliar = solicitud.NotaFamiliar;
            if(solicitud.GastosDiarios > 0) ficha.GastosDiarios = solicitud.GastosDiarios;
            if(solicitud.GastosIglesia > 0) ficha.GastosIglesia = solicitud.GastosIglesia;
            if(solicitud.GastosRadio > 0) ficha.GastosRadio = solicitud.GastosRadio;
            if(solicitud.GastosMunicipalidad > 0) ficha.GastosMunicipalidad = solicitud.GastosMunicipalidad;
            if(solicitud.GastosTraslado > 0) ficha.GastosTraslado = solicitud.GastosTraslado;
            if(solicitud.GastosReduccion > 0) ficha.GastosReduccion = solicitud.GastosReduccion;
            if(solicitud.GastosReinscripcion > 0) ficha.GastosReinscripcion = solicitud.GastosReinscripcion;
            if(!string.IsNullOrEmpty(solicitud.GastosNombreDoctor)) ficha.GastosNombreDoctor = solicitud.GastosNombreDoctor;
            if(solicitud.GastosDoctor > 0) ficha.GastosDoctor = solicitud.GastosDoctor;
            if(solicitud.GastosEscribano > 0) ficha.GastosEscribano = solicitud.GastosEscribano;
            if(solicitud.GastosTraslado2 > 0) ficha.GastosTraslado2 = solicitud.GastosTraslado2;
            if(solicitud.GastosCremacion > 0) ficha.GastosCremacion = solicitud.GastosCremacion;
            if(solicitud.GastosFlores > 0) ficha.GastosFlores = solicitud.GastosFlores;
            if(solicitud.TotalCtaCte > 0) ficha.TotalCtaCte = solicitud.TotalCtaCte;
            if(solicitud.TotalContado > 0) ficha.TotalContado = solicitud.TotalContado;
            if(solicitud.FechaC != null) ficha.FechaC=Convert.ToDateTime(solicitud.FechaC);
            if(solicitud.FechaA != null) ficha.FechaA=Convert.ToDateTime(solicitud.FechaA);
            if(solicitud.FechaI != null) ficha.FechaI=Convert.ToDateTime(solicitud.FechaI);
            return ficha;
        }
      
        private contrato.entidades.FichaSepelio FichaNuevaRespuesta(dominio.entidades.FichaSepelio fichaNueva)
        {
            var fichaSepelio = new contrato.entidades.FichaSepelio();
            fichaSepelio.NombreExtinto = fichaNueva.NombreExtinto;
            fichaSepelio.ApellidoExtinto = fichaNueva.ApellidoExtinto;
            fichaSepelio.DNIExtinto = fichaNueva.DNIExtinto;
            fichaSepelio.FechaNacimientoExtinto = fichaNueva.FechaNacimientoExtinto;
            fichaSepelio.EdadExtinto=fichaNueva.EdadExtinto;
            fichaSepelio.EstadoCivil = fichaNueva.EstadoCivil;
            fichaSepelio.Doctor = fichaNueva.Doctor;
            fichaSepelio.Barrio= fichaNueva.Barrio;
            fichaSepelio.CasaDeDuelo=fichaNueva.CasaDeDuelo;
            fichaSepelio.GastoDoctor=fichaNueva.GastoDoctor;
            fichaSepelio.Clinica=fichaNueva.Clinica;
            fichaSepelio.FechaFallecimiento = fichaNueva.FechaFallecimiento;
            fichaSepelio.HoraFallecimiento=fichaNueva.HoraFallecimiento;
            fichaSepelio.LugarDeFallecimiento=fichaNueva.LugarDeFallecimiento;
            fichaSepelio.Hora=fichaNueva.Hora;
            fichaSepelio.Servicio=fichaNueva.Servicio;
            fichaSepelio.Iglesia=fichaNueva.Iglesia;
            fichaSepelio.Nota=fichaNueva.Nota;
            fichaSepelio.TipoAtaud=fichaNueva.TipoAtaud;
            fichaSepelio.Cementerio=fichaNueva.Cementerio;
            fichaSepelio.Sector=fichaNueva.Sector;
            fichaSepelio.Numero=fichaNueva.Numero;
            fichaSepelio.NombreFamiliar=fichaNueva.NombreFamiliar;
            fichaSepelio.ApellidoFamiliar=fichaNueva.ApellidoFamiliar;
            fichaSepelio.DNIFamiliar=fichaNueva.DNIFamiliar;
            fichaSepelio.TitularFacturacion=fichaNueva.TitularFacturacion;
            fichaSepelio.TelefonoFamiliar=fichaNueva.TelefonoFamiliar;
            fichaSepelio.EmailFamiliar=fichaNueva.EmailFamiliar;
            fichaSepelio.DomicilioFamiliar=fichaNueva.DomicilioFamiliar;
            fichaSepelio.NotaFamiliar=fichaNueva.NotaFamiliar;
            fichaSepelio.GastosDiarios=fichaNueva.GastosDiarios;
            fichaSepelio.GastosIglesia=fichaNueva.GastosIglesia;
            fichaSepelio.GastosRadio=fichaNueva.GastosRadio;
            fichaSepelio.GastosMunicipalidad=fichaNueva.GastosMunicipalidad;
            fichaSepelio.GastosTraslado=fichaNueva.GastosTraslado;
            fichaSepelio.GastosReduccion=fichaNueva.GastosReduccion;
            fichaSepelio.GastosReinscripcion=fichaNueva.GastosReinscripcion;
            fichaSepelio.GastosNombreDoctor=fichaNueva.GastosNombreDoctor;
            fichaSepelio.GastosDoctor=fichaNueva.GastosDoctor;
            fichaSepelio.GastosEscribano=fichaNueva.GastosEscribano;
            fichaSepelio.GastosTraslado2=fichaNueva.GastosTraslado2;
            fichaSepelio.GastosCremacion=fichaNueva.GastosCremacion;
            fichaSepelio.GastosFlores=fichaNueva.GastosFlores;
            fichaSepelio.TotalCtaCte=fichaNueva.TotalCtaCte;
            fichaSepelio.TotalContado=fichaNueva.TotalContado;
            fichaSepelio.FechaC=fichaNueva.FechaC;
            fichaSepelio.FechaA=fichaNueva.FechaA;
            fichaSepelio.FechaI=fichaNueva.FechaI;

            return fichaSepelio;
        }
      }

}