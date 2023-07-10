
namespace iXlsxWriter.ComponentModel.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Serie
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
