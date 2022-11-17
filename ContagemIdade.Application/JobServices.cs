using ContagemIdade.Domain.Interfaces;
using System.Threading.Tasks;

namespace ContagemIdade.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class JobServices : IJobServices
    {
        private readonly ICoderByteRepository _rep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rep"></param>
        public JobServices(ICoderByteRepository rep)
        {
            _rep = rep;
        }

        public async Task Execute()
        {
            var result = await _rep.GetData();
        }
    }
}
