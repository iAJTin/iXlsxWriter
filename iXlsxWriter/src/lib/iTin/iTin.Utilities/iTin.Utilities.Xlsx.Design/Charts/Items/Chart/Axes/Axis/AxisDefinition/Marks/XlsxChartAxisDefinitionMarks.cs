
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
///Represents the visual setting the labels of a axis.
/// </summary>
public partial class XlsxChartAxisDefinitionMarks : ICombinable<XlsxChartAxisDefinitionMarks>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const TickMarkStyle DefaultMajor = TickMarkStyle.Cross;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const TickMarkStyle DefaultMinor = TickMarkStyle.Cross;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private TickMarkStyle _major;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private TickMarkStyle _minor;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartAxisDefinitionMarks"/> class.
    /// </summary>
    public XlsxChartAxisDefinitionMarks()
    {
        Major = DefaultMajor;
        Minor = DefaultMinor;
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
    void ICombinable<XlsxChartAxisDefinitionMarks>.Combine(XlsxChartAxisDefinitionMarks reference) => Combine(reference);

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing default chart axis marks definition settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartAxisDefinitionMarks"/> reference containing the default chart axis marks definition settings.
    /// </value>
    public static XlsxChartAxisDefinitionMarks Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element.
    /// </summary>
    /// <value>
    /// The element that represents the container element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxChartAxisDefinition Parent { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred position of major tick marks for an axis. The default is <see cref="TickMarkStyle.Cross"/>.
    /// </summary>
    /// <value>
    /// Preferred position of major tick marks for an axis.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultMajor)]
    public TickMarkStyle Major
    {
        get => _major;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _major = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred position of minor tick marks for an axis. The default is <see cref="TickMarkStyle.Cross"/>.
    /// </summary>
    /// <value>
    /// Preferred position of minor tick marks for an axis.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultMinor)]
    public TickMarkStyle Minor
    {
        get => _minor;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _minor = value;
        }
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
        Major.Equals(DefaultMajor) &&
        Minor.Equals(DefaultMinor);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxChartAxisDefinitionMarks Clone()
    {
        var cloned = (XlsxChartAxisDefinitionMarks)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this axes.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxChartAxisDefinitionMarksOptions options)
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
    public virtual void Combine(XlsxChartAxisDefinitionMarks reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Major.Equals(DefaultMajor))
        {
            Major = reference.Major;
        }

        if (Minor.Equals(DefaultMinor))
        {
            Minor = reference.Minor;
        }
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxChartAxisDefinition"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxChartAxisDefinition reference)
    {
        Parent = reference;
    }

    #endregion
}
