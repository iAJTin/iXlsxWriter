
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shape;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxShapeContentAlignmentOptions"/> class.
    /// </summary>
    public XlsxShapeContentAlignmentOptions()
    {
        Horizontal = null;
    }

    #endregion

    #region interfaces

    #region ICloneable

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

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxShapeContentAlignment"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShapeContentAlignmentOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxShapeContentAlignmentOptions Default => new();

    #endregion

    #region public properties

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

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Horizontal == null;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxShapeContentAlignmentOptions Clone() => (XlsxShapeContentAlignmentOptions)MemberwiseClone();

    #endregion
}
