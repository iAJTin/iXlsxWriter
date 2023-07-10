
namespace iXlsxWriter.ComponentModel.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Informe
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("configuracionInforme")]
        public Configuracion ConfiguracionInforme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locales")]
        public List<Local> Locales { get; set; } // Estructura que representará cada uno de los locales (series)
    }
}
