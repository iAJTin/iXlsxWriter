
namespace iXlsxWriter.ComponentModel
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public class Configuracion
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tituloInforme")]
        public string TituloInforme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("valoresPor")]
        public string ValoresPor { get; set; } // Posibles valores: DIA, MES

        /// <summary>
        /// 
        /// </summary>
        // En caso de ValoresPor = DIA sería FechaInicio=01/06/2020 y FechaFin=30/06/2020
        // En caso de ValoresPor = MES sería FechaInicio=01/06/2020 y FechaFin=31/12/2020 si se ha elegido de Junio 2020 a Diciembre 2020
        [JsonProperty("fechaInicioPeriodo")]
        public DateTime FechaInicioPeriodo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fechaFinPeriodo")]
        public DateTime FechaFinPeriodo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("parametro")]
        public string Parametro { get; set; }  // Nombre del concepto sobre el que se hace el informe, ej: //Núm.robos//

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tipo")]
        public string Tipo { get; set; }  // Posibles valores: SUMA, COMPARATIVA

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hacerMedia")]
        public bool HacerMedia { get; set; } // Indicará si se debe hacer la media

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("colorMedia")]
        public string ColorMedia { get; set; } // Valor color serie media en HEX

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("idiomaInforme")]
        public string IdiomaInforme { get; set; } // Abreviatura del idioma del usuario que hace el informe (ES,EN,FR)
    }
}
