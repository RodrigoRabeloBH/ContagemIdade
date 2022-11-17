using ContagemIdade.Domain.Model;
using System.Threading.Tasks;

namespace ContagemIdade.Domain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICoderByteRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Entity> GetData();
    }
}
