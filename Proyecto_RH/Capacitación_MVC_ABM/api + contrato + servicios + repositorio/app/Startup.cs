using contrato.servicios.cliente;
using contrato.servicios.fichaSepelio;
using datos.Infraestructura;
using dominio.infraestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using servicio;
using Microsoft.EntityFrameworkCore;
using dominio;

namespace capacitacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuracion = configuration;
        }

        public IConfiguration Configuracion { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection servicios)
        {
            servicios.AddControllers();
            servicios.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            
            servicios.AddDbContext<Contexto>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuracion.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));
            servicios.AddScoped(typeof(IServicioCliente), typeof(ServicioCliente));
            servicios.AddScoped(typeof(IServicioFichaSepelio), typeof(ServicioFichaSepelio));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:5002");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
