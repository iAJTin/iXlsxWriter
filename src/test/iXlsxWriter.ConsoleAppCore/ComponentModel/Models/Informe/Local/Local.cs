
namespace iXlsxWriter.ComponentModel.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Local
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; } // Valor en HEX

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("series")]
        public List<Serie> Series { get; set; }
    }
}