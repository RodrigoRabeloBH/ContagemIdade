using ContagemIdade.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ContagemIdade.Job
{
    /// <summary>
    /// 
    /// </summary>
    public class Job : IJob
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IJobServices _services;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<Job> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="logger"></param>
        public Job(IJobServices services, ILogger<Job> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            _logger.LogInformation("[Inicio do job]");

            await _services.Execute();
        }
    }
}
