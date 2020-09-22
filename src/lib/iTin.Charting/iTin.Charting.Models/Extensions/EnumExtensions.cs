
namespace iTin.Charting.Models
{
    using iTin.Core.Models.Design.Enums;

    using Design;

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
            switch (alignment)
            {
                case KnownTextAlignment.Near:
                    return KnownHorizontalAlignment.Left;

                case KnownTextAlignment.Far:
                    return KnownHorizontalAlignment.Right;

                default:
                case KnownTextAlignment.Center:
                    return KnownHorizontalAlignment.Center;
            }
        }
    }
}
