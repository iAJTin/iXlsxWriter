
using System.Drawing;

using iTin.Core.Models.Design.Enums;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents the visual setting the labels of a axis.
/// </summary>
public interface IAxisElementModel 
{
    /// <summary>
    /// Gets or sets the interval between the main or secondary grid lines. The default value is zero <b>(0)</b>.
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Single?" /> value that represents the interval between the grid lines. 
    /// </value>
    float? Interval { get; set; }

    /// <summary>
    /// Gets or sets the line color of grid lines. The default value is <b>(Black)</b>.
    /// </summary>
    /// <value>
    /// An <see cref="T:System.Int32" /> value that represents the line color in pixels. 
    /// </value>
    string LineColor { get; set; }

    /// <summary>
    /// Gets or sets the line style of a grid. The default value is one <b>(<see cref="F:iTin.Charting.Models.Design.KnownLineStyle.Continuous"/>)</b>.
    /// </summary>
    /// <value>
    /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownLineStyle"/>.
    /// </value>
    KnownLineStyle LineDashStyle { get; set; }

    /// <summary>
    /// Gets or sets the line width of grid lines. The default value is one <b>(1)</b>.
    /// </summary>
    /// <value>
    /// An <see cref="T:System.Int32" /> value that represents the line width in pixels.
    /// </value>
    int LineWidth { get; set; }

    /// <summary>
    /// Gets or sets a value that determines whether the lines grid are visible. The default value is <b>YesNo.No</b>.
    /// </summary>
    /// <value>
    /// <b>Yes</b> if display the the lines grid; otherwise, <b>No</b>.
    /// </value>
    YesNo Show { get; set; }


    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for this font.
    /// </summary>
    /// <returns>
    /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    Color GetColor();
}
