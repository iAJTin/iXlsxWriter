
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic axis chart definition. Includes information for the category and value axes.
/// </summary>
public partial class XlsxChartAxisDefinition : ICombinable<XlsxChartAxisDefinition>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const GridLine DefaultGridLine = GridLine.None;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private GridLine _gridLine;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartAxisDefinitionMarks _marks;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartAxisDefinitionLabels _labels;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartAxisDefinitionValues _values;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartAxisDefinition"/> class.
    /// </summary>
    public XlsxChartAxisDefinition()
    {
        Show = DefaultShow;
        GridLines = DefaultGridLine;
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

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxChartAxisDefinition>.Combine(XlsxChartAxisDefinition reference) => Combine(reference);

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing default chart axis settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartAxisDefinition"/> reference containing the default chart axis settings.
    /// </value>
    public static XlsxChartAxisDefinition Default => new();

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
    public bool LabelsSpecified => !Labels.IsDefault;

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
    public bool MarksSpecified => !Marks.IsDefault;

    /// <summary>
    /// Gets the parent element.
    /// </summary>
    /// <value>
    /// The element that represents the container element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxChartAxis Parent { get; private set; }

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
    public bool ValuesSpecified => !Values.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred grid lines for axis. The default is <see cref="GridLine.None"/>.
    /// </summary>
    /// <value>
    /// Preferred grid lines for axis.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("gridlines")]
    [DefaultValue(DefaultGridLine)]
    public GridLine GridLines
    {
        get => _gridLine;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _gridLine = value;
        }
    }

    /// <summary>
    ///  Gets or sets a reference that contains the visual setting of labels axis
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartAxisDefinitionLabels"/> reference that contains the visual setting of labels axis.
    /// </value>
    [XmlElement]
    [JsonProperty("labels")]
    public XlsxChartAxisDefinitionLabels Labels
    {
        get
        {
            _labels ??= new XlsxChartAxisDefinitionLabels();
            _labels.SetParent(this);

            return _labels;
        }
        set => _labels = value;
    }

    /// <summary>
    ///  Gets or sets a reference that contains the visual setting of mark axis
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartAxisDefinitionMarks"/> reference that contains the visual setting of mark axis.
    /// </value>
    [XmlElement]
    [JsonProperty("marks")]
    public XlsxChartAxisDefinitionMarks Marks
    {
        get
        {
            _marks ??= new XlsxChartAxisDefinitionMarks();
            _marks.SetParent(this);

            return _marks;
        }
        set => _marks = value;
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays this axis. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> displays this axis; Otherwise, <see cref="YesNo.No"/>. 
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
    ///  Gets or sets a reference that contains the visual setting of values axis
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartAxisDefinitionValues"/> reference that contains the visual setting of values axis.
    /// </value>
    [XmlElement]
    [JsonProperty("values")]
    public XlsxChartAxisDefinitionValues Values
    {
        get
        {
            _values ??= new XlsxChartAxisDefinitionValues();
            _values.SetParent(this);

            return _values;
        }
        set => _values = value;
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Labels.IsDefault &&
        Marks.IsDefault &&
        Values.IsDefault &&
        Show.Equals(DefaultShow) &&
        GridLines.Equals(DefaultGridLine);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxChartAxisDefinition Clone()
    {
        var cloned = (XlsxChartAxisDefinition)MemberwiseClone();
        cloned.Labels = Labels.Clone();
        cloned.Marks = Marks.Clone();
        cloned.Values = Values.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this axes.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxChartAxisDefinitionOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Horizontal
    //    Horizontal.ApplyOptions(options.Horizontal);
    //    #endregion

    //    #region Vertical
    //    Vertical.ApplyOptions(options.Vertical);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxChartAxisDefinition reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        Labels.Combine(reference.Labels);
        Marks.Combine(reference.Marks);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartAxes"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxChartAxis reference)
    {
        Parent = reference;
    }

    #endregion
}
