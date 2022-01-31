using contrato.servicios.cliente;
using contrato.entidades;
using contrato.servicios.cliente.respuestas;
using contrato.servicios.cliente.solicitudes;
using System.Threading.Tasks;
using System.Linq;
using dominio.infraestructura;
using System.Linq.Expressions;
using System;
using dominio;

namespace servicio
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorio<dominio.entidades.Cliente> _repositorioCliente;

        public ServicioCliente(IRepositorio<dominio.entidades.Cliente> repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }



        public async Task<RespuestaCrear> Crear(SolicitudCrear solicitud)
        {
            var respuesta = new RespuestaCrear();
            var nuevo_cliente = MapearCliente(solicitud);
            await _repositorioCliente.Crear(nuevo_cliente);
            respuesta.Id = nuevo_cliente.Id;
            return respuesta;
        }

        public async Task<RespuestaEliminar> Eliminar(int id)
        {
            var respuesta = new RespuestaEliminar();
            var clienteAEliminar = await _repositorioCliente.Buscar(c => c.Id == id);
            await _repositorioCliente.Eliminar(clienteAEliminar[0]);

            var todosLosClientes = await _repositorioCliente.BuscarTodos();
            respuesta.Clientes = todosLosClientes.Select(c => new Cliente()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Estado = c.Estado,
                Correo = c.Correo
            }).ToList();
            return respuesta;
        }

        public async Task<RespuestaObtener> Obtener(SolicitudObtener solicitud)
        {
            var respuesta = new RespuestaObtener();
            var predicado = ArmarPredicado(solicitud);
            var respuesta_servicio = await _repositorioCliente.Buscar(predicado);
            respuesta.Clientes = respuesta_servicio.Select(c => new Cliente()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Estado = c.Estado,
                Correo = c.Correo
            }).ToList();
            return respuesta;
        }



        private Expression<Func<dominio.entidades.Cliente, bool>> ArmarPredicado(SolicitudObtener solicitud)
        {
            var predicado = CrearPredicado.Verdadero<dominio.entidades.Cliente>();
            if (!string.IsNullOrEmpty(solicitud.Apellido)) predicado = predicado.Y(c => c.Apellido.ToLower().Contains(solicitud.Apellido.ToLower()));
            if (solicitud.Id > 0) predicado = predicado.Y(c => c.Id == solicitud.Id);
            if (!string.IsNullOrEmpty(solicitud.Nombre)) predicado = predicado.Y(c => c.Nombre.ToLower().Contains(solicitud.Nombre.ToLower()));
            if (solicitud.Estado > 0) predicado = predicado.Y(c => c.Estado == solicitud.Estado);
            if (!string.IsNullOrEmpty(solicitud.Correo)) predicado = predicado.Y(c => c.Correo.ToLower().Contains(solicitud.Correo.ToLower()));
            return predicado;
        }

        private dominio.entidades.Cliente MapearCliente(SolicitudCrear solicitud)
        {
            var cliente = new dominio.entidades.Cliente();
            cliente.Nombre = solicitud.Nombre;
            cliente.Apellido = solicitud.Apellido;
            cliente.Correo = solicitud.Correo;
            cliente.Estado = solicitud.Estado;
            cliente.FechaAlta = DateTime.Now;
            return cliente;
        }

        public async Task<RespuestaActualizar> Actualizar(int id, SolicitudActualizar solicitud)
        {
            var respuesta = new RespuestaActualizar();
            var cliente = await _repositorioCliente.Obtener(id);
            cliente = MapearActualizarCliente(cliente, solicitud);
            await _repositorioCliente.Actualizar(cliente);
            cliente = await _repositorioCliente.Obtener(id);

            respuesta.Cliente = new Cliente();
            respuesta.Cliente.Id = cliente.Id;
            respuesta.Cliente.Nombre = cliente.Nombre;
            respuesta.Cliente.Apellido = cliente.Apellido;
            respuesta.Cliente.Correo = cliente.Correo;
            respuesta.Cliente.Estado = cliente.Estado;

            return respuesta;
        }

        private dominio.entidades.Cliente MapearActualizarCliente(dominio.entidades.Cliente cliente, SolicitudActualizar solicitud)
        {

            cliente.Nombre = solicitud.Nombre;
            cliente.Apellido = solicitud.Apellido;
            cliente.Correo = solicitud.Correo;
            cliente.Estado = solicitud.Estado;

            return cliente;
        }
    }
}
