using ContagemIdade.Domain.Interfaces;
using ContagemIdade.Domain.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContagemIdade.Infrastructure.Http
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CoderByteRepository : ICoderByteRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<CoderByteRepository> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _url = Environment.GetEnvironmentVariable("ENPOINT");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientFactory"></param>
        /// <param name="logger"></param>
        public CoderByteRepository(IHttpClientFactory clientFactory, ILogger<CoderByteRepository> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<Entity> GetData()
        {
            _logger.LogInformation("[Buscando dados: {0}]", DateTime.Now);

            var result = new Entity();

            var http = _clientFactory.CreateClient("CoderByte");

            var response = await http.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<Entity>(content);
            }
            else
                _logger.LogInformation("[Algo de errado nao esta certo.]");

            return result;
        }
    }
}
