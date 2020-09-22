
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellMerge"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxCellMergeOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxCellMergeOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellMergeOptions"/> class.
        /// </summary>
        public XlsxCellMergeOptions()
        {
            Cells = null;
            Orientation = null;
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

        #region [public] {static} (XlsxCellMergeOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxCellMerge instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellMerge"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellMergeOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxCellMergeOptions Default => new XlsxCellMergeOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (int?) Cells: Gets or sets the merge cells in an existing XlsxCellMerge instance
        /// <summary>
        /// Gets or sets the merge cells in an existing <see cref="XlsxCellMerge"/>" instance.
        /// </summary>
        /// <value>
        /// Merge cells.
        /// </value>
        [XmlAttribute]
        [JsonProperty("cells")]
        public int? Cells { get; set; }
        #endregion

        #region [public] (KnownMergeOrientation?) Orientation: Gets or sets a value that indicates preferred merge orientation for an existing XlsxCellMerge instance
        /// <summary>
        /// Gets or sets a value that indicates preferred merge orientation for an existing <see cref="XlsxCellMerge"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
        /// </value>
        [XmlAttribute]
        [JsonProperty("orientation")]
        public KnownMergeOrientation? Orientation { get; set; }
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
        public override bool IsDefault => base.IsDefault && Cells == null && Orientation == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellMergeOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellMergeOptions Clone() => (XlsxCellMergeOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
