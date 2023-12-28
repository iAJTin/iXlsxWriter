
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Picture;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxPictureContent"/> instance.
/// </summary>
[Serializable]
public class XlsxPictureContentOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPictureContentOptions"/> class.
    /// </summary>
    public XlsxPictureContentOptions()
    {
        Show = null;
        Color = null;
        Transparency = null;
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
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxPictureContent"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPictureContentOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxPictureContent"/> instance.
    /// </value>
    public static XlsxPictureContentOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred picture content color in an existing <see cref="XlsxPictureContent"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred picture content color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether an existing <see cref="XlsxPictureContent"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("show")]
    public YesNo? Show { get; set; }

    /// <summary>
    /// Gets or sets the preferred picture content transparency percentage value in an existing <see cref="XlsxPictureContent"/>" instance.
    /// </summary>
    /// <value>
    /// Preferred picture content transparency percentage value.
    /// </value>
    [XmlAttribute]
    [JsonProperty("transparency")]
    public int? Transparency { get; set; }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Show == null &&
        Color == null &&
        Transparency == null;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxPictureContentOptions Clone() => (XlsxPictureContentOptions) MemberwiseClone();

    #endregion
}
