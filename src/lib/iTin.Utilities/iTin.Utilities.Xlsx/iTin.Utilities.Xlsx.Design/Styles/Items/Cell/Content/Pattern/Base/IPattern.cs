
using System.Diagnostics;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Drawing;
    using System.Xml.Serialization;
    
    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic pattern.
    /// </summary>
    public interface IPattern : ICombinable<IPattern>, ICloneable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        bool IsDefault { get; }

        /// <summary>
        /// Gets a value indicating whether this style is an empty style.
        /// </summary>
        /// <value>
        /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
        /// </value>        
        bool IsEmpty { get; }



        /// <summary>
        /// Gets or sets preferred pattern color.
        /// </summary>
        /// <value>
        /// Preferred pattern color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        string Color { get; set; }

        /// <summary>
        /// Gets or sets preferred pattern type.
        /// </summary>
        /// <value>
        /// Preferred pattern type.
        /// </value>
        [XmlAttribute]
        [JsonProperty("patterntype")]
        KnownPatternType PatternType { get; set; }



        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
        /// </returns> 
        Color GetColor();
    }
}
