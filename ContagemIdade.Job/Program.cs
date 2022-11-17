using ContagemIdade.Job.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ContagemIdade.Job
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddDependecyResolver()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            try
            {
                await serviceProvider.GetService<IJob>().Start();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }
    }
}
