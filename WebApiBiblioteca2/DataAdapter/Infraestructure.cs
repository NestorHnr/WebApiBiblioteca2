using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DataAdapter.Repositories;

namespace WebApiBiblioteca2.DataAdapter
{
    public static class Infraestructure
    {
        public static void AddWebApi_DbContext(this IServiceCollection services,
                           IConfiguration configuration)
        {
            var conectionString = configuration.GetConnectionString("conexion");
            services.AddDbContext<WebApiBiblioteca2_DbContext>(builder =>
            {
                builder.UseSqlServer(conectionString);
            });

            services.AddHttpContextAccessor();
            services.AddRepositories();

        }
        public static void AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IAutorRepositoryPorts, AutorRepositoryAdapters>();
            services.AddScoped<IComentarioRepositoryPorts, ComentarioRepositoryAdapters>();
            services.AddScoped<ILibroRepositoryPorts, LibroRepositoryAdapters>();
        }
    }
}
