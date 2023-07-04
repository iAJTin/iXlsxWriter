
using System;

using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> aggregate definition.
/// </summary>
public class QualifiedAggregateDefinition : ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="QualifiedAggregateDefinition"/> class.
    /// </summary>
    public QualifiedAggregateDefinition()
    {
        HasAutoFilter = YesNo.No;
        WorkSheet = string.Empty;
        Range = XlsxRange.Default;
        AggregateType = KnownAggregateType.Sum;
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
    /// Gets or sets the preferred aggregate function to apply. The default is <see cref="KnownAggregateType.Sum"/>.
    /// </summary>
    /// <value>
    /// Preferred aggregate function to apply.
    /// </value>
    public KnownAggregateType AggregateType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the auto filter is enabled. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if auto filter is enabled; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    public YesNo HasAutoFilter {  get; set; }

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
    /// A <see cref="XlsxBaseRange"/> containing the data range.
    /// </value>
    public XlsxBaseRange Range { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public QualifiedAggregateDefinition Clone()
    {
        var cloned = (QualifiedAggregateDefinition)MemberwiseClone();
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
    public override string ToString() => $"WorkSheet=\"{WorkSheet}\", Range=\"{Range}\", AggregateType={AggregateType}";

    #endregion
}
