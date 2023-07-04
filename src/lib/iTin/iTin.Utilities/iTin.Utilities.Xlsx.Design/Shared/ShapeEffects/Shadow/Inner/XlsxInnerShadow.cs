
using System;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
/// Represents a inner shadow.
/// </summary>
public partial class XlsxInnerShadow : ICombinable<XlsxInnerShadow>, ICloneable
{
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
    void ICombinable<XlsxInnerShadow>.Combine(XlsxInnerShadow reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow None => new();

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow TopLeft => new() {Show = YesNo.Yes, Angle = 225, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow Top => new() { Show = YesNo.Yes, Angle = 270, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow TopRight => new() { Show = YesNo.Yes, Angle = 315, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow Left => new() { Show = YesNo.Yes, Angle = 180, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow Center => new() { Show = YesNo.Yes, Angle = 0, Blur = 9, Offset = 0, Transparency = 0};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow Right => new() { Show = YesNo.Yes, Angle = 0, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow DownLeft => new() { Show = YesNo.Yes, Angle = 135, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow Down => new() { Show = YesNo.Yes, Angle = 90, Blur = 5, Offset = 4, Transparency = 50};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxInnerShadow DownRight => new() {Show = YesNo.Yes, Blur = 5, Offset = 4, Transparency = 50};

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxInnerShadow Clone()
    {
        var cloned = (XlsxInnerShadow)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(XlsxInnerShadowOptions options)
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
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxInnerShadow reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);
    }

    #endregion
}
