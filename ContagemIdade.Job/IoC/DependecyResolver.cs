using ContagemIdade.Application;
using ContagemIdade.Domain.Interfaces;
using ContagemIdade.Infrastructure.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ContagemIdade.Job.IoC
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DependecyResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependecyResolver(this IServiceCollection services)
        {
            RegisterDependecy(services);
            RegisterHttpClient(services);
            RegisterRepositories(services);
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterDependecy(IServiceCollection services)
        {
            services.AddScoped<IJob, Job>();
            services.AddScoped<IJobServices, JobServices>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICoderByteRepository, CoderByteRepository>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("CoderByte", httpClient =>
            {
                httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("CODER_BYTE_API"));
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(10)));
        }
    }
}
