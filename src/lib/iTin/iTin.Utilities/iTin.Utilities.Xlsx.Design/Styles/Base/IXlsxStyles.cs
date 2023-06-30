
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// Defines a generic xlsx styles collection
    /// </summary>
    public interface IXlsxStyles : IStyles
    {
        /// <summary>
        /// Returns specified style by name
        /// </summary>
        /// <param name="value">Style name to get</param>
        /// <returns>
        /// A <see cref="IStyle"/> reference.
        /// </returns>
        new IXlsxStyle GetBy(string value);
    }
}
