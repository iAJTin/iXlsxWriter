
namespace iTin.Charting.Models.Design.Options;

using System;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="AxisLabelsModel"/> instance.
/// </summary>
[Serializable]
public sealed class AxisLabelsOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="AxisLabelsOptions"/> class.
    /// </summary>
    public AxisLabelsOptions()
    {
        Angle = null;
        Format = null;
        Interval = null;
        Show = null;

        Font = FontOptions.Default;
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
    /// Gets a reference that contains the set of available settings to model an existing <see cref="AxisLabelsModel"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public static AxisLabelsOptions Default => new();

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
        Angle == null &&
        Format == null &&
        Interval == null &&
        Show == null &&
        Font.IsDefault;

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
    public bool FontSpecified => !Font.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that represents the angle expressed in degrees at which the font is drawn in an existing <see cref="AxisLabelsModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic. The values admitted are <b>-90</b> to <b>90</b>
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Int32"/> value the angle at which the font is drawn.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public int? Angle { get; set; }

    /// <summary>
    /// Gets or sets a value that defines the font for axis labels in an existing <see cref="AxisLabelsModel"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="FontOptions"/> instance.
    /// </value>
    public FontOptions Font { get; set; }

    /// <summary>
    /// Gets or sets the preferred axis label format in an existing <see cref="AxisLabelsModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the  preferred axis label format.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the interval between labels of axis in an existing <see cref="AxisLabelsModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Single"/> value that contains the interval labels of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public float? Interval { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether displays the axis labels in an existing <see cref="AxisLabelsModel"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo? Show { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public AxisLabelsOptions Clone()
    {
        var clonned = (AxisLabelsOptions)MemberwiseClone();
        clonned.Font = Font.Clone();

        return clonned;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current object.
    /// </returns>
    public override string ToString() => !IsDefault ? "Modified" : "Default";

    #endregion
}
