
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContent : ICombinable<XlsxCellContent>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    void ICombinable<XlsxCellContent>.Combine(XlsxCellContent reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxCellContent reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);

        var referenceDataType = reference.DataType;
        _dataType ??= referenceDataType.Type switch
        {
            KnownDataType.Currency => new CurrencyDataType(),
            KnownDataType.DateTime => new DateTimeDataType(),
            KnownDataType.Numeric => new NumberDataType(),
            KnownDataType.Percentage => new PercentageDataType(),
            KnownDataType.Scientific => new ScientificDataType(),
            _ => new TextDataType()
        };

        if (_dataType.Type.Equals(referenceDataType.Type))
        {
            DataType.Combine(referenceDataType);
        }

        Merge.Combine(reference.Merge);
        Pattern.Combine(reference.Pattern);
        Alignment.Combine(reference.Alignment);
    }
}
