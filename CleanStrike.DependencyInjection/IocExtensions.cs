using CleanStrike.Core.Engine;
using CleanStrike.Core.Models;
using CleanStrike.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanStrike.DependencyInjection
{
    public static class IocExtensions
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.RegisterEngines();
            services.RegisterRepositories();
        }
        public static void RegisterEngines(this IServiceCollection services)
        {
            services.AddTransient<ICleanStrikeService, CleanStrikeService>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {            
            services.AddTransient<ICarromBoardRepository, CarromBoardRepository>();            
        }
    }
}
