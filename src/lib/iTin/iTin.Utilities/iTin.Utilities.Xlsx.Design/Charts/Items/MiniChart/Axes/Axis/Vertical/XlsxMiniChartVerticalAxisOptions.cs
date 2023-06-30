
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxMiniChartVerticalAxisOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxMiniChartHorizontalAxisOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartVerticalAxisOptions"/> class.
        /// </summary>
        public XlsxMiniChartVerticalAxisOptions()
        {
            Max = null;
            Min = null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxMiniChartVerticalAxisOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxMiniChartVerticalAxis instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxMiniChartVerticalAxisOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
        /// </value>
        public static XlsxMiniChartVerticalAxisOptions Default => new XlsxMiniChartVerticalAxisOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Max: Gets or sets a value that contains the maximun value for the axis in an existing XlsxMiniChartVerticalAxis instance
        /// <summary>
        /// Gets or sets a value that contains the maximun value for the axis in an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartVerticalAxisOptions"/> instance.
        /// </value>
        [XmlAttribute]
        [JsonProperty("max")]
        public string Max { get; set; }
        #endregion

        #region [public] (string) Min: Gets or sets a value that contains the minimun value for the axis in an existing XlsxMiniChartVerticalAxis instance
        /// <summary>
        /// Gets or sets a value that contains the minimun value for the axis in an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartVerticalAxisOptions"/> instance.
        /// </value>
        [XmlAttribute]
        [JsonProperty("min")]
        public string Min { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Max == null && Min == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartVerticalAxisOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartVerticalAxisOptions Clone() => (XlsxMiniChartVerticalAxisOptions) MemberwiseClone();
        #endregion

        #endregion
    }
}
