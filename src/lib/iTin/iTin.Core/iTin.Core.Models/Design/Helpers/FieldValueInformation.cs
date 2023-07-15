
using System.Drawing;

namespace iTin.Core.Models.Design.ComponentModel;

/// <summary>
/// 
/// </summary>
public class FieldValueInformation
{
    #region public static readonly properties

    /// <summary>
    /// Gets the default.
    /// </summary>
    /// <value>
    /// The default.
    /// </value>
    public static FieldValueInformation Default => new()
    {
        Comment = null,
        IsNumeric = false,
        IsNegative = false,
        IsErrorValue = false,
        Value = string.Empty,
        Format = "@",
        NegativeColor = Color.Empty,
        FormattedValue = string.Empty,
    };

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public object FormattedValue { get; set; }

    /// <summary>
    /// Gets or sets the format.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public bool IsDateTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [is error value].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [is error value]; otherwise, <c>false</c>.
    /// </value>
    public bool IsErrorValue { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public bool IsNegative { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public bool IsNumeric { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public bool IsText { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public Color NegativeColor { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public object Value { get; set; }

    /// <summary>
    /// Gets or sets the comment.
    /// </summary>
    /// <value>
    /// The data.
    /// </value>
    public Comment Comment { get; set; }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a <see cref="string"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> that represents this instance.
    /// </returns>
    public override string ToString() => $"Value=\"{Value}\", Format=\"{Format}\"";

    #endregion
}
