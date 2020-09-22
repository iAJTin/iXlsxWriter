
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies the known pattern type of content.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownPatternType
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Solid
        /// </summary>
        Solid,

        /// <summary>
        /// Gray75
        /// </summary>
        Gray75,

        /// <summary>
        /// Gray50
        /// </summary>
        Gray50,

        /// <summary>
        /// Gray25
        /// </summary>
        Gray25,

        /// <summary>
        /// Gray125
        /// </summary>
        Gray125,

        /// <summary>
        /// Gray625
        /// </summary>
        Gray625,

        /// <summary>
        /// HorzStripe
        /// </summary>
        HorzStripe,

        /// <summary>
        /// VertStripe
        /// </summary>
        VertStripe,

        /// <summary>
        /// ReverseDiagStripe
        /// </summary>
        ReverseDiagStripe,

        /// <summary>
        /// DiagStripe
        /// </summary>
        DiagStripe,

        /// <summary>
        /// DiagCross
        /// </summary>
        DiagCross,

        /// <summary>
        /// ThickDiagCross
        /// </summary>
        ThickDiagCross,

        /// <summary>
        /// ThinHorzStripe
        /// </summary>
        ThinHorzStripe,

        /// <summary>
        /// ThinVertStripe
        /// </summary>
        ThinVertStripe,

        /// <summary>
        /// ThinReverseDiagStripe
        /// </summary>
        ThinReverseDiagStripe,

        /// <summary>
        /// ThinDiagStripe
        /// </summary>
        ThinDiagStripe,

        /// <summary>
        /// ThinHorzCross
        /// </summary>
        ThinHorzCross,

        /// <summary>
        /// ThinDiagCross
        /// </summary>
        ThinDiagCross
    }
}
