
using System.Diagnostics;

using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// Represents a qualified <b>xlsx</b> aggregate definition.
/// </summary>
public class XlsxQualifiedFormulaResolver
{
    #region private readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QualifiedAggregateDefinition _model;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxQualifiedFormulaResolver"/> class.
    /// </summary>
    /// <param name="aggregate">Aggregate's data.</param>
    public XlsxQualifiedFormulaResolver(QualifiedAggregateDefinition aggregate)
    {
        _model = aggregate;

        WorkSheet = string.Empty;
        HasAutoFilter = YesNo.No;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether the auto filter is enabled. The dafault is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if auto filter is enabled; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    public YesNo HasAutoFilter { get; set; }

    /// <summary>
    /// Gets or sets a value containing worksheet name.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing worksheet name.
    /// </value>
    public string WorkSheet { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Returns string containing aggregate's formula.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> containing the formula.
    /// </returns>
    public string Resolve()
    {
        if (_model.AggregateType == KnownAggregateType.None)
        {
            return string.Empty;
        }

        var type = _model.AggregateType switch
        {
            KnownAggregateType.Average => HasAutoFilter == YesNo.Yes ? 101 : 1,
            KnownAggregateType.Count => HasAutoFilter == YesNo.Yes ? 103 : 3,
            KnownAggregateType.Max => HasAutoFilter == YesNo.Yes ? 104 : 4,
            KnownAggregateType.Min => HasAutoFilter == YesNo.Yes ? 105 : 5,
            KnownAggregateType.Sum => HasAutoFilter == YesNo.Yes ? 109 : 9,
            _ => HasAutoFilter == YesNo.Yes ? 109 : 9
        };

        return string.IsNullOrEmpty(WorkSheet)
            ? $"SUBTOTAL({type}, {_model.Range})"
            : $"SUBTOTAL({type}, '{WorkSheet}'!{_model.Range})";
    }

    #endregion
}
