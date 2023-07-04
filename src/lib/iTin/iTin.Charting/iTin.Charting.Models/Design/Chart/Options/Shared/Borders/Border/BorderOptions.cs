
using System;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="BorderModel"/> instance.
/// </summary>
[Serializable]
public class BorderOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BorderOptions"/> class.
    /// </summary>
    public BorderOptions()
    {
        Color = null;
        Show = null;
        Style = null;
        Width = null;
        Position = null;

        Shadow = ShadowOptions.Default;
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
    /// Gets a reference that contains the set of available settings to model an existing <see cref="BorderModel"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public static BorderOptions Default => new();

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        Color == null &&
        Show == null &&
        Style == null &&
        Width == null &&
        Position == null &&
        Shadow.IsDefault;

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool ShadowSpecified => !Shadow.IsDefault;

    #endregion
    
    #region public properties

    /// <summary>
    /// Gets or sets the preferred border color in an existing <see cref="BorderModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred border color.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates preferred border position. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of values of enumeration <see cref="KnownBorderPosition"/>. 
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [JsonConverter(typeof(StringEnumConverter))]
    public KnownBorderPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets a value that defines the shadow of the border in an existing <see cref="BorderModel"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="ShadowOptions"/> instance.
    /// </value>
    public ShadowOptions Shadow { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether an existing <see cref="BorderModel"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo? Show { get; set; }

    /// <summary>
    /// Gets or sets the preferred border line style in an existing <see cref="BorderModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownLineStyle"/>. 
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [JsonConverter(typeof(StringEnumConverter))]
    public KnownLineStyle? Style { get; set; }

    /// <summary>
    /// Gets or sets a value that contains width of the title border in an existing <see cref="BorderModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Int32"/> value that determines the width of the border, in pixels
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public int? Width { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public BorderOptions Clone()
    {
        var clonned = (BorderOptions)MemberwiseClone();
        clonned.Shadow = Shadow.Clone();

        return clonned;
    }

    #endregion
}
