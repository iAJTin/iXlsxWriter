
using iTin.Core.Models.Design.Enums;

using iTin.Charting.Models.Design;

namespace iTin.Charting.Models;

static class EnumExtensions
{
    /// <summary>
    /// Converts a value of the enumerated type <see cref="KnownTextAlignment"/> to the enumerated type <see cref="KnownHorizontalAlignment"/>.
    /// </summary>
    /// <param name="alignment">Value to convert.</param>
    /// <returns>
    /// One of the values of <see cref="KnownHorizontalAlignment"/>.
    /// </returns>
    public static KnownHorizontalAlignment ToHorizontalAlignment(this KnownTextAlignment alignment)
    {
        return alignment switch
        {
            KnownTextAlignment.Near => KnownHorizontalAlignment.Left,
            KnownTextAlignment.Far => KnownHorizontalAlignment.Right,
            KnownTextAlignment.Center => KnownHorizontalAlignment.Center,
            _ => KnownHorizontalAlignment.Center
        };
    }
}
