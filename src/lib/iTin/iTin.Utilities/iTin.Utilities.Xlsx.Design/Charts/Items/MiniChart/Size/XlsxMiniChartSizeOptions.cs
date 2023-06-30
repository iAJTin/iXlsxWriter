
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChartSize"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxMiniChartSizeOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxMiniChartSizeOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartSizeOptions"/> class.
        /// </summary>
        public XlsxMiniChartSizeOptions()
        {
            VerticalCells = null;
            HorizontalCells = null;
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

        #region [public] {static} (XlsxMiniChartSizeOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxMiniChartSize instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChartSize"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxMiniChartSizeOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxMiniChartSizeOptions Default => new XlsxMiniChartSizeOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (int?) VerticalCells: Gets or sets the vertical cells in existing XlsxCellMerge instance
        /// <summary>
        /// Gets or sets the vertical cells in existing <see cref="XlsxMiniChartSize"/>" instance.
        /// </summary>
        /// <value>
        /// Merge cells.
        /// </value>
        [XmlAttribute]
        [JsonProperty("vertical-cells")]
        public int? VerticalCells { get; set; }
        #endregion

        #region [public] (int?) HorizontalCells: Gets or sets the vertical cells in an existing in existing XlsxCellMerge instance
        /// <summary>
        /// Gets or sets the horizontal cells in existing <see cref="XlsxMiniChartSize"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
        /// </value>
        [XmlAttribute]
        [JsonProperty("horizontal-cells")]
        public int? HorizontalCells { get; set; }
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
        public override bool IsDefault => base.IsDefault && HorizontalCells == null && VerticalCells == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartSizeOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartSizeOptions Clone() => (XlsxMiniChartSizeOptions) MemberwiseClone();
        #endregion

        #endregion
    }
}
