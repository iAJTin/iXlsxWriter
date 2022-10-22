
using iTin.Utilities.Xlsx.Design.Styles;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Acts as base class for insert actions with style.
    /// </summary>
    public abstract class InsertWithStyleBase : InsertLocationBase
    {
        #region public properties

        #region [public] (object) Data: Gets or sets a reference
        /// <summary>
        /// Gets or sets a reference to data to insert.
        /// </summary>
        /// <value>
        /// A <see cref="object"/> object that contains a reference to data to insert.
        /// </value>
        public object Data { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) Style: Gets or sets a reference to cell style
        /// <summary>
        /// Gets or sets a reference to cell style.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> object that contains a reference to cell style
        /// </value>
        public XlsxCellStyle Style { get; set; }
        #endregion

        #endregion
    }
}
