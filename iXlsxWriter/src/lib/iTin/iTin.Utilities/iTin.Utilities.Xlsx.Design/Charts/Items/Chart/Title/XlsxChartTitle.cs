
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Represents the visual setting of title. Includes a text, visibility, orientation, border and font.
/// </summary>
public partial class XlsxChartTitle : ICombinable<XlsxChartTitle>
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultText = "";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const TextOrientation DefaultOrientation = TextOrientation.Horizontal;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FontModel _font;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBorder _border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private TextOrientation _orientation;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartTitle"/> class.
    /// </summary>
    public XlsxChartTitle()
    {
        Show = DefaultShow;
        Text = DefaultText;
        Orientation = DefaultOrientation;
    }

    #endregion

    #region interfaces

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxChartTitle>.Combine(XlsxChartTitle reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Gets default chart title configuration.
    /// </summary>
    /// <value>
    /// Default chart title configuration.
    /// </value>
    public static XlsxChartTitle Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool BorderSpecified => !Border.IsDefault;

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool FontSpecified => !Font.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of legend border.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBorder" /> reference that contains the visual setting of legend border.          
    /// </value>
    [XmlElement]
    [JsonProperty("border")]
    public XlsxBorder Border
    {
        get => _border ??= XlsxBorder.Default;
        set => _border = value;
    }

    /// <summary>
    /// Gets or sets the font model.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of a font.            
    /// </value>
    [XmlElement]
    [JsonProperty("font")]
    public FontModel Font
    {
        get => _font ??= FontModel.DefaultFont;
        set => _font = value;
    }

    /// <summary>
    /// Gets or sets preferred chart title orientation. The default is <see cref="TextOrientation.Horizontal"/>.
    /// </summary>
    /// <value>
    /// Preferred chart title orientation.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("orientation")]
    [DefaultValue(DefaultOrientation)]
    public TextOrientation Orientation
    {
        get => _orientation;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _orientation = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays legend. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display legend; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("show")]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => _show;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _show = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred text of title.
    /// </summary>
    /// <value>
    /// Preferred text of title.
    /// </value>
    [XmlAttribute]
    [JsonProperty("text")]
    public string Text { get; set; }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        Font.IsDefault &&
        Border.IsDefault &&
        Show.Equals(DefaultShow) &&
        Orientation.Equals(DefaultOrientation) &&
        string.IsNullOrEmpty(Text);

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this style.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxChartLegendOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Content
    //    Content.ApplyOptions(options.Content);
    //    #endregion

    //    #region Font
    //    Font.ApplyOptions(options.Font);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxChartTitle reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        if (Orientation.Equals(DefaultOrientation))
        {
            Orientation = reference.Orientation;
        }

        if (!string.IsNullOrEmpty(Text))
        {
            Text = reference.Text;
        }

        Font.Combine(reference.Font);
        Border.Combine(reference.Border);
    }

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxChartTitle Clone()
    {
        var cloned = (XlsxChartTitle) MemberwiseClone();
        cloned.Font = Font.Clone();
        cloned.Border = Border.Clone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }

    #endregion
}
