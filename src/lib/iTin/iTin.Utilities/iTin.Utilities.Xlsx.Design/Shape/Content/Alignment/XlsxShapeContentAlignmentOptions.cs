
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shape
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxShapeContentAlignment"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxShapeContentAlignmentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxShapeContentAlignmentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxShapeContentAlignmentOptions"/> class.
        /// </summary>
        public XlsxShapeContentAlignmentOptions()
        {
            Horizontal = null;
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

        #region [public] {static} (XlsxShapeContentAlignmentOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxShapeContentAlignment instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxShapeContentAlignment"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShapeContentAlignmentOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxShapeContentAlignmentOptions Default => new XlsxShapeContentAlignmentOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHorizontalAlignment?) Horizontal: Gets or sets the preferred horizontal alignment in an existing XlsxShapeContentAlignment instance
        /// <summary>
        /// Gets or sets the preferred horizontal alignment in an existing <see cref="XlsxShapeContentAlignment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownHorizontalAlignment"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("horizontal")]
        public KnownHorizontalAlignment? Horizontal { get; set; }
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
        public override bool IsDefault => base.IsDefault && Horizontal == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxShapeContentAlignmentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxShapeContentAlignmentOptions Clone() => (XlsxShapeContentAlignmentOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
