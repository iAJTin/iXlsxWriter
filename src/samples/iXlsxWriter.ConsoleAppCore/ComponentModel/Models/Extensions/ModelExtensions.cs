
namespace iXlsxWriter.ComponentModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains common extensions for data model.
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        /// Converts a <see cref="Configuracion"/> reference into a new localized dictionary.
        /// </summary>
        /// <param name="data">configuration data</param>
        /// <returns>
        /// A dictopnary reference containaing localized configuration values.
        /// </returns>
        public static Dictionary<string, object> ToDictionary(this Configuracion data)
        {
            bool isSpanishLanguage = data.IdiomaInforme.Equals("ES", StringComparison.OrdinalIgnoreCase);
            bool isEnglishLanguage = data.IdiomaInforme.Equals("EN", StringComparison.OrdinalIgnoreCase);

            string summaryValuesByLiteral = "Valores Por";
            if (!isSpanishLanguage)
            {
                summaryValuesByLiteral = !isEnglishLanguage ? "Valeurs par" : "Values By";
            }

            string summaryInitialDateLiteral = "Fecha Inicio";
            if (!isSpanishLanguage)
            {
                summaryInitialDateLiteral = !isEnglishLanguage ? "Date initiale" : "Initial Date";
            }

            string summaryEndDateLiteral = "Fecha Fin";
            if (!isSpanishLanguage)
            {
                summaryEndDateLiteral = !isEnglishLanguage ? "Date de fin" : "End Date";
            }

            string summaryParameterLiteral = "Parámetro";
            if (!isSpanishLanguage)
            {
                summaryParameterLiteral = !isEnglishLanguage ? "Paramètre" : "Parameter";
            }

            string summaryTypeLiteral = "Tipo";
            if (!isSpanishLanguage)
            {
                summaryTypeLiteral = !isEnglishLanguage ? "Type" : "Type";
            }

            var result = new Dictionary<string, object>
            {
                {summaryParameterLiteral, data.Parametro},
                {summaryTypeLiteral, data.Tipo},
                {summaryValuesByLiteral, data.ValoresPor},
                {summaryInitialDateLiteral, data.FechaInicioPeriodo},
                {summaryEndDateLiteral, data.FechaFinPeriodo},
            };

            return result;
        }
    }
}
