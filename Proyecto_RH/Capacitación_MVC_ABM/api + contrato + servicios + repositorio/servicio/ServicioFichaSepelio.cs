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
            var nueva_ficha = MapearFicha(solicitud);
            await _repositorioFichaSepelio.Crear(nueva_ficha);
            respuesta.Id = nueva_ficha.Id;
            return respuesta;
        }

        public async Task<RespuestaEliminar> Eliminar(int id)
        {
            var respuesta = new RespuestaEliminar();
            var fichaAEliminar = await _repositorioFichaSepelio.Buscar(c => c.Id == id);
            if(fichaAEliminar.Count() >0){
                await _repositorioFichaSepelio.Eliminar(fichaAEliminar[0]);

                var todosLasFichas = await _repositorioFichaSepelio.BuscarTodos();
                respuesta.Fichas = todosLasFichas.Select(c => new FichaSepelio()
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
                    GastosTranslado=c.GastosTranslado,
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
            
                return respuesta;
            }else{
                return null;
            }
            
            
        }

        public async Task<RespuestaObtener> Obtener(SolicitudObtener solicitud)
        {
            var respuesta = new RespuestaObtener();
            var predicado = ArmarPredicado(solicitud);
            var respuesta_servicio = await _repositorioFichaSepelio.Buscar(predicado);
            respuesta.Fichas = respuesta_servicio.Select(c => new FichaSepelio()
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
                GastosTranslado=c.GastosTranslado,
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

        private dominio.entidades.FichaSepelio MapearFicha(SolicitudCrear solicitud)
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
            ficha.GastosTranslado=solicitud.GastosTranslado;
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

                
                respuesta.fichaSepelio = new FichaSepelio();
                respuesta.fichaSepelio.NombreExtinto = fichaNueva.NombreExtinto;
                respuesta.fichaSepelio.ApellidoExtinto = fichaNueva.ApellidoExtinto;
                respuesta.fichaSepelio.DNIExtinto = fichaNueva.DNIExtinto;
                respuesta.fichaSepelio.FechaNacimientoExtinto = fichaNueva.FechaNacimientoExtinto;
                respuesta.fichaSepelio.EdadExtinto=fichaNueva.EdadExtinto;
                respuesta.fichaSepelio.EstadoCivil = fichaNueva.EstadoCivil;
                respuesta.fichaSepelio.Doctor = fichaNueva.Doctor;
                respuesta.fichaSepelio.Barrio= fichaNueva.Barrio;
                respuesta.fichaSepelio.CasaDeDuelo=fichaNueva.CasaDeDuelo;
                respuesta.fichaSepelio.GastoDoctor=fichaNueva.GastoDoctor;
                respuesta.fichaSepelio.Clinica=fichaNueva.Clinica;
                respuesta.fichaSepelio.FechaFallecimiento = fichaNueva.FechaFallecimiento;
                respuesta.fichaSepelio.HoraFallecimiento=fichaNueva.HoraFallecimiento;
                respuesta.fichaSepelio.LugarDeFallecimiento=fichaNueva.LugarDeFallecimiento;
                respuesta.fichaSepelio.Hora=fichaNueva.Hora;
                respuesta.fichaSepelio.Servicio=fichaNueva.Servicio;
                respuesta.fichaSepelio.Iglesia=fichaNueva.Iglesia;
                respuesta.fichaSepelio.Nota=fichaNueva.Nota;
                respuesta.fichaSepelio.TipoAtaud=fichaNueva.TipoAtaud;
                respuesta.fichaSepelio.Cementerio=fichaNueva.Cementerio;
                respuesta.fichaSepelio.Sector=fichaNueva.Sector;
                respuesta.fichaSepelio.Numero=fichaNueva.Numero;
                respuesta.fichaSepelio.NombreFamiliar=fichaNueva.NombreFamiliar;
                respuesta.fichaSepelio.ApellidoFamiliar=fichaNueva.ApellidoFamiliar;
                respuesta.fichaSepelio.DNIFamiliar=fichaNueva.DNIFamiliar;
                respuesta.fichaSepelio.TitularFacturacion=fichaNueva.TitularFacturacion;
                respuesta.fichaSepelio.TelefonoFamiliar=fichaNueva.TelefonoFamiliar;
                respuesta.fichaSepelio.EmailFamiliar=fichaNueva.EmailFamiliar;
                respuesta.fichaSepelio.DomicilioFamiliar=fichaNueva.DomicilioFamiliar;
                respuesta.fichaSepelio.NotaFamiliar=fichaNueva.NotaFamiliar;
                respuesta.fichaSepelio.GastosDiarios=fichaNueva.GastosDiarios;
                respuesta.fichaSepelio.GastosIglesia=fichaNueva.GastosIglesia;
                respuesta.fichaSepelio.GastosRadio=fichaNueva.GastosRadio;
                respuesta.fichaSepelio.GastosMunicipalidad=fichaNueva.GastosMunicipalidad;
                respuesta.fichaSepelio.GastosTranslado=fichaNueva.GastosTranslado;
                respuesta.fichaSepelio.GastosReduccion=fichaNueva.GastosReduccion;
                respuesta.fichaSepelio.GastosReinscripcion=fichaNueva.GastosReinscripcion;
                respuesta.fichaSepelio.GastosNombreDoctor=fichaNueva.GastosNombreDoctor;
                respuesta.fichaSepelio.GastosDoctor=fichaNueva.GastosDoctor;
                respuesta.fichaSepelio.GastosEscribano=fichaNueva.GastosEscribano;
                respuesta.fichaSepelio.GastosTraslado2=fichaNueva.GastosTraslado2;
                respuesta.fichaSepelio.GastosCremacion=fichaNueva.GastosCremacion;
                respuesta.fichaSepelio.GastosFlores=fichaNueva.GastosFlores;
                respuesta.fichaSepelio.TotalCtaCte=fichaNueva.TotalCtaCte;
                respuesta.fichaSepelio.TotalContado=fichaNueva.TotalContado;
                respuesta.fichaSepelio.FechaC=fichaNueva.FechaC;
                respuesta.fichaSepelio.FechaA=fichaNueva.FechaA;
                respuesta.fichaSepelio.FechaI=fichaNueva.FechaI;
                 
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
            if(solicitud.FechaNacimientoExtinto != null) ficha.FechaNacimientoExtinto=solicitud.FechaNacimientoExtinto;
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
            if(!string.IsNullOrEmpty(solicitud.ApellidoExtinto)) ficha.ApellidoFamiliar = solicitud.ApellidoFamiliar;
            if(!string.IsNullOrEmpty(solicitud.Cementerio)) ficha.Cementerio = solicitud.Cementerio;
            if(solicitud.DNIFamiliar > 0) ficha.DNIFamiliar = solicitud.DNIFamiliar;
            if(!string.IsNullOrEmpty(solicitud.TitularFacturacion)) ficha.TitularFacturacion = solicitud.TitularFacturacion;
            if(!string.IsNullOrEmpty(solicitud.TelefonoFamiliar)) ficha.TelefonoFamiliar = solicitud.TelefonoFamiliar;
            if(!string.IsNullOrEmpty(solicitud.EmailFamiliar)) ficha.EmailFamiliar = solicitud.EmailFamiliar;
            







            return ficha;
        }
      }

}