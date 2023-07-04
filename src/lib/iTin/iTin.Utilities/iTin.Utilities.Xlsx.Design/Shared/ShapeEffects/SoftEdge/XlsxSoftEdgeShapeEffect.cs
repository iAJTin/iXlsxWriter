
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> soft edge shape effect.
/// </summary>
public partial class XlsxSoftEdgeShapeEffect : ICombinable<XlsxSoftEdgeShapeEffect>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultSize = 0.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _size;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxSoftEdgeShapeEffect"/> class.
    /// </summary>
    public XlsxSoftEdgeShapeEffect()
    {
        Size = DefaultSize;
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
    void ICombinable<XlsxSoftEdgeShapeEffect>.Combine(XlsxSoftEdgeShapeEffect reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect None => new();

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect SoftEdge1 => new() { Show = YesNo.Yes, Size = 1};

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect SoftEdge2 => new() { Show = YesNo.Yes, Size = 2.5f};

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect SoftEdge5 => new() { Show = YesNo.Yes, Size = 5.0f};

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect SoftEdge10 => new() { Show = YesNo.Yes, Size = 10.0f};

    /// <summary>
    /// Returns a new instance containig the soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
    /// </value>
    public static XlsxSoftEdgeShapeEffect SoftEdge25 => new() { Show = YesNo.Yes, Size = 25.0f};

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred reflection effect size value, expressed in points. The default is <b>0.0</b>.
    /// </summary>
    /// <value>
    /// Preferred reflection effect size value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0.0 and 100.0.</exception>
    [XmlAttribute]
    [JsonProperty("size")]
    [DefaultValue(DefaultSize)]
    public float Size
    {
        get => _size;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Size), value, 0.0f, 100.0f);

            _size = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays reflection effect. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display reflection effect; otherwise, <see cref="YesNo.No"/>.
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
        Size.Equals(DefaultSize) &&
        Show.Equals(DefaultShow);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxSoftEdgeShapeEffect Clone()
    {
        var cloned = (XlsxSoftEdgeShapeEffect)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxSoftEdgeShapeEffectOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Size
        float? sizeOption = options.Size;
        bool sizeHasValue = sizeOption.HasValue;
        if (sizeHasValue)
        {
            Size = sizeOption.Value;
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
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxSoftEdgeShapeEffect reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }
    }

    #endregion
}
