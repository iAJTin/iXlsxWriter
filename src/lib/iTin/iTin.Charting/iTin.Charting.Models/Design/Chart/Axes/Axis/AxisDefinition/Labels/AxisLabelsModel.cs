
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Charting.Models.Design.Options;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents the visual setting the labels of a axis.
/// </summary>
public sealed partial class AxisLabelsModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultAngle = 0;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultInterval = 0.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultFormat = "n0";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FontModel _font;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="AxisLabelsModel" /> class.
    /// </summary>
    public AxisLabelsModel()
    {
        Angle = DefaultAngle;
        Format = DefaultFormat;
        Interval = DefaultInterval;
        Show = DefaultShow;
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

    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [Browsable(false)]
    [JsonIgnore]
    public AxisDefinitionModel Parent { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that represents the angle at which the font is drawn. The default value is zero <b>(0)</b>. The values admitted are <b>-90</b> to <b>90</b>
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Int32" /> that contains the angle at which the font is drawn.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultAngle)]
    public int Angle { get; set; }

    /// <summary>
    /// Gets or sets a reference to the font model defined for this labels.
    /// </summary>
    /// <value>
    /// Reference to the font model defined for this title.
    /// </value>
    public FontModel Font
    {
        get => _font ??= new FontModel();
        set => _font = value;
    }

    /// <summary>
    /// Gets or sets the interval labels of axis.The default is <b>n0</b>.
    /// <para>
    /// Typical formats configuration.
    /// <list type="table">  
    ///   <listheader>  
    ///     <term>Format</term>  
    ///     <term>Input</term>  
    ///     <term>Output</term>  
    ///   </listheader>  
    ///   <item>  
    ///     <term>n</term>  
    ///     <term>1234</term>  
    ///     <term>1,234.00</term>  
    ///   </item>  
    ///   <item>  
    ///     <term>n0</term>  
    ///     <term>1234</term>  
    ///     <term>1,234</term>  
    ///   </item>  
    /// </list>  
    /// </para>
    /// </summary>
    /// <value>
    /// A <see cref="T:System.String" /> that contains the interval labels of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultFormat)]
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the interval labels of axis. The default value is zero <b>(0)</b>.
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Single" /> that contains the interval labels of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultInterval)]
    public float? Interval { get; set; }

    /// <summary>
    /// Gets or sets a value that determines whether the labels axis are visible. The default value is <b>YesNo.No</b>.
    /// </summary>
    /// <value>
    /// <b>true</b> if display the the labels axis are visible; otherwise, <b>false</b>.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo Show { get; set; }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault =>
        Font.IsDefault &&
        Angle.Equals(DefaultAngle) &&
        Format.Equals(DefaultFormat) &&
        Interval.Equals(DefaultInterval) &&
        Show.Equals(DefaultShow);

    #endregion

    #region public methods

    /// <summary>
    /// Apply specified options to this axis labels.
    /// </summary>
    public void ApplyOptions(AxisLabelsOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Angle
        int? angleOption = options.Angle;
        bool angleHasValue = angleOption.HasValue;
        if (angleHasValue)
        {
            Angle = angleOption.Value;
        }
        #endregion

        #region Font
        Font.ApplyOptions(options.Font);
        #endregion

        #region Format
        string formatOption = options.Format;
        bool formatHasValue = !formatOption.IsNullValue();
        if (formatHasValue)
        {
            Format = formatOption;
        }
        #endregion

        #region Interval
        float? intervalOption = options.Interval;
        bool intervalHasValue = intervalOption.HasValue;
        if (intervalHasValue)
        {
            Interval = intervalOption.Value;
        }
        #endregion

        #region Show
        YesNo? showOption = options.Show;
        bool showHasValue = showOption.HasValue;
        if (showHasValue)
        {
            Show = showOption.Value;
        }
        #endregion
    }

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public AxisLabelsModel Clone()
    {
        var cloned = (AxisLabelsModel)MemberwiseClone();
        cloned.Font = Font.Clone();
        cloned.SetParent(Parent);

        return cloned;
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

    #region internal methods

    /// <summary>
    /// Sets the parent element of the element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    internal void SetParent(AxisDefinitionModel reference)
    {
        Parent = reference;
    }

    #endregion
}
