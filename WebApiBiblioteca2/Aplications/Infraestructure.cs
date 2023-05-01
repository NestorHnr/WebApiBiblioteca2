using WebApiBiblioteca2.Aplications.UseCase;

namespace WebApiBiblioteca2.Aplications
{
    public static class Infraestructure
    {
        public static void AddRepositoriesUseCase(this IServiceCollection services)
        {
            services.AddScoped<AutorUseCase>();
            services.AddScoped<LibroUseCase>();
            services.AddScoped<ComentarioUsecase>();
        }
    }
}
