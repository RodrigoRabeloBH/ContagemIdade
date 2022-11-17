using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace ContagemIdade.Domain.Model
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Entity
    {

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
