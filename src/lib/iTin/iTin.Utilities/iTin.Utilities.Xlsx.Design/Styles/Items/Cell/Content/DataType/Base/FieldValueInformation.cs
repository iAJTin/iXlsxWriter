
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System.Drawing;

    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// Specifies content data type.
    /// </summary>
    public class FieldValueInformation
    {
        #region public static properties

        #region [public] {static} (FieldValueInformation) Default: Gets defaults instance
        /// <summary>
        /// Gets defaults instance.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public static FieldValueInformation Default => new FieldValueInformation
        {
            Comment = null,
            IsNumeric = false,
            IsNegative = false,
            IsErrorValue = false,
            Value = string.Empty,
            FormattedValue = null,
            Style = BaseStyle.Default,
            NegativeColor = Color.Empty,
        };
        #endregion

        #endregion

        #region public properties

        #region [public] (object) FormattedValue: Gets or sets a value that contains the value processed after applying the indicated style
        /// <summary>
        /// Gets or sets a value that contains the value processed after applying the indicated style.
        /// </summary>
        /// <value>
        /// Formatted value after applying the indicated style.
        /// </value>
        public object FormattedValue { get; set; }
        #endregion

        #region [public] (bool) IsDateTime: Gets or sets a value that indicates whether the value is a date
        /// <summary>
        /// Gets or sets a value that indicates whether the value is a date.
        /// </summary>
        /// <value>
        /// <b>true</b> if the value is a date; otherwise <b>false</b>.
        /// </value>
        public bool IsDateTime { get; set; }
        #endregion

        #region [public] (bool) IsErrorValue: Gets or sets a value that indicates whether an error occurred while processing the value
        /// <summary>
        /// Gets or sets a value that indicates whether an error occurred while processing the value.
        /// </summary>
        /// <value>
        /// <b>true</b> if an error occurred while processing the value; otherwise <b>false</b>.
        /// </value>
        public bool IsErrorValue { get; set; }
        #endregion

        #region [public] (bool) IsNegative: Gets or sets a value that indicates whether the value is negative value
        /// <summary>
        /// Gets or sets a value that indicates whether the value is negative value.
        /// </summary>
        /// <value>
        /// <b>true</b> if the value is negative; otherwise <b>false</b>.
        /// </value>
        public bool IsNegative { get; set; }
        #endregion

        #region [public] (bool) IsNumeric: Gets or sets a value that indicates whether the value is numeric
        /// <summary>
        /// Gets or sets a value that indicates whether the value is numeric.
        /// </summary>
        /// <value>
        /// <b>true</b> if the value is numeric; otherwise <b>false</b>.
        /// </value>
        public bool IsNumeric { get; set; }
        #endregion

        #region [public] (bool) IsText: Gets or sets a value that indicates whether the value is a string
        /// <summary>
        /// Gets or sets a value that indicates whether the value is a string.
        /// </summary>
        /// <value>
        /// <b>true</b> if the value is a string; otherwise <b>false</b>.
        /// </value>
        public bool IsText { get; set; }
        #endregion

        #region [public] (Color) NegativeColor: Gets or sets a value that contains the negative color to use
        /// <summary>
        /// Gets or sets a value that contains the negative color to use.
        /// </summary>
        /// <value>
        /// A <see cref="Color"/> structure that contains the negative color to use.
        /// </value>
        public Color NegativeColor { get; set; }
        #endregion

        #region [public] (object) Value: Gets or sets the value to evaluate
        /// <summary>
        /// Gets or sets the value to evaluate.
        /// </summary>
        /// <value>
        /// The value to evaluate.
        /// </value>
        public object Value { get; set; }
        #endregion

        #region [public] (IStyle) Style: Gets or sets a value that contains the style to apply to the value to display
        /// <summary>
        /// Gets or sets a value that contains the style to apply to the value to display.
        /// </summary>
        /// <value>
        /// A <see cref="BaseStyle"/> that contains the style to apply to the value to display.
        /// </value>
        public IStyle Style { get; set; }
        #endregion

        #region [public] (XlsxCellComment) Comment: Gets or sets a value that contains the comment to display if an error occurs when handling the value
        /// <summary>
        /// Gets or sets a value that contains the comment to display if an error occurs when handling the value.
        /// </summary>
        /// <value>
        /// <see cref="XlsxCellComment"/> that contains the comment to display if an error occurs when handling the value.
        /// </value>
        public XlsxCellComment Comment { get; set; }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString() => $"Value=\"{Value}\", Style=\"{Style.Name}\", FormattedValue=\"{FormattedValue}\"";

        #endregion

        #endregion
    }
}
