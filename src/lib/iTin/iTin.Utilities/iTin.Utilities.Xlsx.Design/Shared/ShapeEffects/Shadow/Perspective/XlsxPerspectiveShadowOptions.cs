
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadowOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxPerspectiveShadow"/> instance.
/// </summary>
[Serializable]
public class XlsxPerspectiveShadowOptions : XlsxBaseShadowOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPerspectiveShadowOptions"/> class.
    /// </summary>
    public XlsxPerspectiveShadowOptions()
    {
        Size = null;
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
    /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxPerspectiveShadow"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static XlsxPerspectiveShadowOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the preferred shadow size, expressed in % in an existing <see cref="XlsxPerspectiveShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred shadow size value, expressed in %.
    /// </value>
    [XmlAttribute]
    [JsonProperty("size")]
    public int? Size { get; set; }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Size == null;

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxPerspectiveShadowOptions Clone() => (XlsxPerspectiveShadowOptions)MemberwiseClone();

    #endregion
}
