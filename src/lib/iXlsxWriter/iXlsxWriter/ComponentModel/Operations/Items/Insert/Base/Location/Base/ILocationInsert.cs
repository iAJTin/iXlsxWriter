
using iTin.Utilities.Xlsx.Design.Shared;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// Defines allowed actions for insert objects
    /// </summary>
    public interface ILocationInsert : IInsert
    {
        /// <summary>
        /// Gets or sets a reference a <see cref="XlsxBaseRange"/> which represents the insert location.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBaseRange"/> object that contains the insert location.
        /// </value>
        XlsxBaseRange Location { get; set; }
    }
}
