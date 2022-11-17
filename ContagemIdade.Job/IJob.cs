using System.Threading.Tasks;

namespace ContagemIdade.Job
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// 
        /// </summary>
        Task Start();
    }
}
