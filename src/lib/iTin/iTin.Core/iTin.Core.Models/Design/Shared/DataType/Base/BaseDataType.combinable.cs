
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

public partial class BaseDataType : ICombinable<BaseDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<BaseDataType>.Combine(BaseDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(BaseDataType reference)
    {
        switch (Type)
        {
            case KnownDataType.Currency:
                ((CurrencyDataType)this).Combine((CurrencyDataType)reference);
                break;

            case KnownDataType.DateTime:
                ((DateTimeDataType)this).Combine((DateTimeDataType)reference);
                break;

            case KnownDataType.Numeric:
                ((NumericDataType)this).Combine((NumericDataType)reference);
                break;

            case KnownDataType.Percentage:
                ((PercentageDataType)this).Combine((PercentageDataType)reference);
                break;

            case KnownDataType.Scientific:
                ((ScientificDataType)this).Combine((ScientificDataType)reference);
                break;

            case KnownDataType.Text:
                break;
        }
    }
}