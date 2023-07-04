
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> range.
/// </summary>
public class QualifiedRangeDefinition : ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="QualifiedRangeDefinition"/> class.
    /// </summary>
    public QualifiedRangeDefinition()
    {
        WorkSheet = string.Empty;
        Range = XlsxRange.Default;
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value containing worksheet name.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing worksheet name.
    /// </value>
    public string WorkSheet { get; set; }

    /// <summary>
    /// Gets or sets a value containig the data range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> containing the data range.
    /// </value>
    public XlsxRange Range { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public QualifiedRangeDefinition Clone()
    {
        var cloned = (QualifiedRangeDefinition)MemberwiseClone();
        cloned.Range = Range.Clone();

        return cloned;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() => $"WorkSheet=\"{WorkSheet}\", Range=\"{Range}\"";

    #endregion
}
