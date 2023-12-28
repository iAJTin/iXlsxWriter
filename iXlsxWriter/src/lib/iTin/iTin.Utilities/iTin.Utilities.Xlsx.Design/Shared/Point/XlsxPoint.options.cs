
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> point.
/// </summary>
public partial class XlsxPoint : IOptions<XlsxPointOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxPointOptions>.ApplyOptions(XlsxPointOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this alignment.
    /// </summary>
    public virtual void ApplyOptions(XlsxPointOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region AbsoluteStrategy
        AbsoluteStrategy? absoluteOption = options.AbsoluteStrategy;
        bool absoluteHasValue = absoluteOption.HasValue;
        if (absoluteHasValue)
        {
            AbsoluteStrategy = absoluteOption.Value;
        }
        #endregion

        #region Column
        int? columnOption = options.Column;
        bool columnHasValue = columnOption.HasValue;
        if (columnHasValue)
        {
            Column = columnOption.Value;
        }
        #endregion

        #region Row
        int? rowOption = options.Row;
        bool rowHasValue = rowOption.HasValue;
        if (rowHasValue)
        {
            Row = rowOption.Value;
        }
        #endregion
    }
}
