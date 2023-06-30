
using iTin.Utilities.Xlsx.Design.Styles;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// Specialization of <see cref="ILocationInsert"/> interface.<br/>
    /// Defines allowed actions for insert objects with style
    /// </summary>
    /// <seealso cref="ILocationInsert"/>
    public interface IInsertWithStyle : ILocationInsert
    {
        /// <summary>
        /// Gets or sets a reference to data to insert.
        /// </summary>
        /// <value>
        /// A <see cref="object"/> object that contains a reference to data to insert.
        /// </value>
        object Data { get; set; }

        /// <summary>
        /// Gets or sets a reference to cell style to use
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> object that contains the cell style.
        /// </value>
        XlsxCellStyle Style { get; set; }
    }
}
