using Backend.Services.Implementations;
using Backend.Services.Interfaces;

namespace Backend.Configurations
{
    public static class DependencyInjectionConfig
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddHttpClient<IRickAndMortyService, RickAndMortyService>();
        services.AddHttpClient<IEpisodeServices, EpisodeServices>();

        services.AddScoped<IRickAndMortyService, RickAndMortyService>();
        services.AddScoped<IEpisodeServices, EpisodeServices>();

        return services;
    }
}

}