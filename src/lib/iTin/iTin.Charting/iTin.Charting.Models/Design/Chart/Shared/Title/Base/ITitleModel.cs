
namespace iTin.Charting.Models.Design
{
    using System.Drawing;

    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Represents the visual setting of title. Includes a text, visibility, orientation, border and font.
    /// </summary>
    public interface ITitleModel
    {
        /// <summary>
        /// Gets or sets preferred back color for this chart title. The default is "<b>(White)</b>".
        /// </summary>
        /// <value>
        /// Preferred back color.
        /// </value>
        string BackColor { get; set; }

        /// <summary>
        /// Gets or sets a reference that contains the visual setting for border of title.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.BorderModel" /> reference that contains the visual setting for border of title.
        /// </value>
        BorderModel Border { get; set; }

        /// <summary>
        /// Gets or sets a reference to the font model defined for this title.
        /// </summary>
        /// <value>
        /// Reference to the font model defined for this title.
        /// </value>
        FontModel Font { get; set; }

        /// <summary>
        /// Gets or sets a value that determines whether displays the title. The default is <b>YesNo.Yes</b>.
        /// </summary>
        /// <value>
        /// <b>YesNo.Yes</b> if display the title; otherwise, <b>YesNo.No</b>. 
        /// </value>
        YesNo Show { get; set; }

        /// <summary>
        /// Gets or sets text of title. The default is <b>""</b>.
        /// </summary>
        /// <value>
        /// The text of title.
        /// </value>
        string Text { get; set; }


        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for chart title backcolor
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        Color GetBackColor();
    }
}
