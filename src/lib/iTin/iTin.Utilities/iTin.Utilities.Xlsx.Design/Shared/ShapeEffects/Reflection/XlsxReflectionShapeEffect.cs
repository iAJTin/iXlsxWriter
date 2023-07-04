
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
/// Represents a <b>xlsx</b> reflection shape effect.
/// </summary>
public partial class XlsxReflectionShapeEffect : ICombinable<XlsxReflectionShapeEffect>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultBlur = 0.5f;
        
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultSize = 35.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultOffset = 0.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultTransparency = 50;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _blur;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _offset;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _transparency;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxReflectionShapeEffect"/> class.
    /// </summary>
    public XlsxReflectionShapeEffect()
    {
        Size = DefaultSize;
        Show = DefaultShow;
        Blur = DefaultBlur;
        Offset = DefaultOffset;
        Transparency = DefaultTransparency;
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
    void ICombinable<XlsxReflectionShapeEffect>.Combine(XlsxReflectionShapeEffect reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect None => new();

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect StrongNoOffset => new() {Show = YesNo.Yes, Transparency = 48};

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect StrongOffset4 => new() { Show = YesNo.Yes, Size = 38, Offset = 4.0f};

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect StrongOffset8 => new() { Show = YesNo.Yes, Size = 40.0f, Offset = 8.0f};

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect SemiNoOffset => new() { Show = YesNo.Yes, Size = 55};

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect SemiOffset4 => new() { Show = YesNo.Yes, Size = 56.0f, Offset = 4.0f };

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect SemiOffset8 => new() { Show = YesNo.Yes, Size = 56.0f, Offset = 8.0f };

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect TotalNoOffset => new() { Show = YesNo.Yes, Size = 90};

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect TotalOffset4 => new() { Show = YesNo.Yes, Size = 90.0f, Offset = 4.0f };

    /// <summary>
    /// Returns a new instance containig the reflection effect
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing the reflection effect
    /// </value>
    public static XlsxReflectionShapeEffect TotalOffset8 => new() { Show = YesNo.Yes, Size = 92.0f, Offset = 8.0f };

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred blur value. The default is <b>0.5</b>.
    /// </summary>
    /// <value>
    /// Preferred blur value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0.0 and 100.0.</exception>
    [XmlAttribute]
    [JsonProperty("blur")]
    [DefaultValue(DefaultBlur)]
    public float Blur
    {
        get => _blur;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Blur), value, 0.0f, 100.0f);

            _blur = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred reflection effect size value, expressed in %. The default is <b>35.0</b>.
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
    /// Gets or sets the reflection distance value expressed in points. The default is <b>0.0</b>.
    /// </summary>
    /// <value>
    /// An <see cref="float"/> value that represents the reflection distance value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0.0 and 100.0.</exception>
    [XmlAttribute]
    [JsonProperty("offset")]
    [DefaultValue(DefaultOffset)]
    public float Offset
    {
        get => _offset;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Offset), value, 0.0f, 100.0f);

            _offset = value;
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

    /// <summary>
    /// Gets or sets the reflection transparency value expresed in %. The default is <b>50</b>.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> value that represents the reflection transparency value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
    [XmlAttribute]
    [JsonProperty("transparency")]
    [DefaultValue(DefaultTransparency)]
    public int Transparency
    {
        get => _transparency;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Transparency), value, 0, 100);

            _transparency = value;
        }
    }

    #endregion

    #region public override properties

    /// <inheritdoc/>
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => 
        base.IsDefault && 
        Blur.Equals(DefaultBlur) && 
        Size.Equals(DefaultSize) && 
        Offset.Equals(DefaultOffset) &&
        Show.Equals(DefaultShow) && 
        Transparency.Equals(DefaultTransparency);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxReflectionShapeEffect Clone()
    {
        var cloned = (XlsxReflectionShapeEffect)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxReflectionShapeEffectOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Blur
        float? blurOption = options.Blur;
        bool blurHasValue = blurOption.HasValue;
        if (blurHasValue)
        {
            Blur = blurOption.Value;
        }
        #endregion

        #region Offset
        float? offsetOption = options.Offset;
        bool offsetHasValue = offsetOption.HasValue;
        if (offsetHasValue)
        {
            Offset = offsetOption.Value;
        }
        #endregion

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

        #region Transparency
        int? transparencyOption = options.Transparency;
        bool transparencyHasValue = transparencyOption.HasValue;
        if (transparencyHasValue)
        {
            Transparency = transparencyOption.Value;
        }
        #endregion
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxReflectionShapeEffect reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Blur.Equals(DefaultBlur))
        {
            Blur = reference.Blur;
        }

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }

        if (Offset.Equals(DefaultOffset))
        {
            Offset = reference.Offset;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        if (Transparency.Equals(DefaultTransparency))
        {
            Transparency = reference.Transparency;
        }
    }

    #endregion
}
