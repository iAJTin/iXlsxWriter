
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
/// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
/// Represents a perspective shadow.
/// </summary>
public partial class XlsxPerspectiveShadow : ICombinable<XlsxPerspectiveShadow>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultSize = 100;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _size;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPerspectiveShadow"/> class.
    /// </summary>
    public XlsxPerspectiveShadow()
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
    void ICombinable<XlsxPerspectiveShadow>.Combine(XlsxPerspectiveShadow reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing a hidden shadow.
    /// </value>
    public static XlsxPerspectiveShadow None => new();

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow TopLeft => new() {Show = YesNo.Yes, Angle = 225, Blur = 6, Offset = 0, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow TopRight => new() { Show = YesNo.Yes, Angle = 315, Blur = 6, Offset = 0, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow DownLeft => new() { Show = YesNo.Yes, Angle = 135, Blur = 6, Offset = 1, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow DownRight => new() { Show = YesNo.Yes, Blur = 6, Offset = 1, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow Down => new() {Show = YesNo.Yes, Angle = 90, Blur = 12, Offset = 25, Transparency = 85};

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred shadow size, expressed in %. The default is <b>100</b>.
    /// </summary>
    /// <value>
    /// Preferred shadow size.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 1 and 200.</exception>
    [XmlAttribute]
    [JsonProperty("size")]
    [DefaultValue(DefaultSize)]
    public int Size
    {
        get => _size;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Size), value, 1, 200);

            _size = value;
        }
    }

    #endregion

    #region public override readonly properties

    /// <inheritdoc/>
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Size.Equals(DefaultSize);

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxPerspectiveShadow Clone()
    {
        var cloned = (XlsxPerspectiveShadow)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(XlsxPerspectiveShadowOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        base.ApplyOptions(options);

        #region Size
        int? sizeOption = options.Size;
        bool sizeHasValue = sizeOption.HasValue;
        if (sizeHasValue)
        {
            Size = sizeOption.Value;
        }
        #endregion
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxPerspectiveShadow reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }
    }

    #endregion
}
