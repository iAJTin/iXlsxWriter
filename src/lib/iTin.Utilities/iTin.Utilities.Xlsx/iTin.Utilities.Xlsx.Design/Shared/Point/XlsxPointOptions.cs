
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxPoint"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxPointOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxPointOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxPointOptions"/> class.
        /// </summary>
        public XlsxPointOptions()
        {
            Row = null;
            Column = null;
            AbsoluteStrategy = null;
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

        #region [public] {static} (XlsxMiniChartOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxPoint instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxPoint"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPointOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxPoint"/> instance.
        /// </value>
        public static XlsxPointOptions Default => new XlsxPointOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (AbsoluteStrategy?) AbsoluteStrategy: Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing XlsxPoint instance
        /// <summary>
        /// Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing <see cref="XlsxPoint"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or one of the enumeration values <see cref="Shared.AbsoluteStrategy"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("absolute-strategy")]
        public AbsoluteStrategy? AbsoluteStrategy { get; set; }
        #endregion

        #region [public] (int?) Column: Gets or sets the column value in an existing XlsxPoint instance
        /// <summary>
        /// Gets or sets the column value in an existing <see cref="XlsxPoint"/>" instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("column")]
        public int? Column { get; set; }
        #endregion

        #region [public] (int?) Row: Gets or sets the preferred action for display hidden values in an existing XlsxMiniChart instance
        /// <summary>
        /// Gets or sets the row value in an existing <see cref="XlsxPoint"/>" instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("row")]
        public int? Row { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Row == null &&
            Column == null &&
            AbsoluteStrategy == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxPointOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxPointOptions Clone() => (XlsxPointOptions) MemberwiseClone();
        #endregion

        #endregion
    }
}
