
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxSoftEdgeShapeEffect"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxSoftEdgeShapeEffectOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxSoftEdgeShapeEffectOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxSoftEdgeShapeEffectOptions"/> class.
        /// </summary>
        public XlsxSoftEdgeShapeEffectOptions()
        {
            Show = null;
            Size = null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #region [public] {static} (XlsxSoftEdgeShapeEffectOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxSoftEdgeShapeEffect instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxSoftEdgeShapeEffect"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static XlsxSoftEdgeShapeEffectOptions Default => new XlsxSoftEdgeShapeEffectOptions();
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Size == null && Show == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (float?) Size: Gets or sets a value that contains the preferred soft edge size value expressed in points in an existing XlsxSoftEdgeShapeEffect instance
        /// <summary>
        /// Gets or sets a value that contains the preferred soft edge size value expressed in points in an existing <see cref="XlsxSoftEdgeShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="float"/> value that represents the preferred soft edge size value expressed in points.
        /// </value>
        [XmlAttribute]
        [JsonProperty("size")]
        public float? Size { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxSoftEdgeShapeEffectOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxSoftEdgeShapeEffectOptions Clone() => (XlsxSoftEdgeShapeEffectOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
