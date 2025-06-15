using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;

namespace Backend.Configurations
{
    public static class DependencyInjectionConfig
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IRickAndMortyService, RickAndMortyService>();
        
        services.AddHttpClient<IRickAndMortyService, RickAndMortyService>();

        return services;
    }
}

}