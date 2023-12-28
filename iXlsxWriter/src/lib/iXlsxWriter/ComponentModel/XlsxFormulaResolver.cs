
using System.Diagnostics;
using System.Globalization;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// Represents a qualified <b>xlsx</b> aggregate definition.
/// </summary>
public class XlsxFormulaResolver
{
    #region private readonly members
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly FieldAggregate _model;
    #endregion

    #region constructor/s

    #region [public] XlsxFormulaResolver(FieldAggregate): Initializes a new instance of the class
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxFormulaResolver" /> class.
    /// </summary>
    /// <param name="aggregate">Aggregate's data.</param>
    public XlsxFormulaResolver(FieldAggregate aggregate)
    {
        _model = aggregate;
    }
    #endregion

    #endregion

    #region public properties

    #region [public] (int) EndRow: Gets or sets a value that represents the end row of the range
    /// <summary>
    /// Gets or sets a value that represents the end row of the range.
    /// </summary>
    /// <value>
    /// End row of the range.
    /// </value>
    public int EndRow { private get; set; }
    #endregion

    #region [public] (int) StartRow: Gets or sets a value that represents the start row of the range
    /// <summary>
    /// Gets or sets a value that represents the start row of the range.
    /// </summary>
    /// <value>
    /// Start row of the range.
    /// </value>
    public int StartRow { private get; set; }
    #endregion

    #endregion

    #region public methods

    #region [public] (string) Resolve(): Returns string containing aggregate's formula
    /// <summary>
    /// Returns string containing aggregate's formula.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> containing the formula.
    /// </returns>
    public string Resolve()
    {
        const string pattern = "SUBTOTAL({0},R[{1}]C:R[{2}]C)";

        var type = int.MaxValue;
        var result = string.Empty;
        if (_model.AggregateType == KnownAggregateType.None)
        {
            return result;
        }
        if (_model.AggregateType != KnownAggregateType.Text)
        {
            type = _model.AggregateType switch
            {
                KnownAggregateType.Average => 101,
                KnownAggregateType.Count => 103,
                KnownAggregateType.Max => 104,
                KnownAggregateType.Min => 105,
                KnownAggregateType.Sum => 109,
                _ => type
            };

            result = string.Format(CultureInfo.InvariantCulture, pattern, type, StartRow, EndRow);
        }
        else
        {
            result = _model.Text;
        }

        return result;
    }
    #endregion

    #endregion
}
