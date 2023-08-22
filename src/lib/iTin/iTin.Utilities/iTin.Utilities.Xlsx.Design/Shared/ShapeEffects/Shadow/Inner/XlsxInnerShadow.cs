
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
/// Represents a inner shadow.
/// </summary>
public partial class XlsxInnerShadow
{
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
}
