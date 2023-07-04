
using System;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

public partial class BaseDataType : ICloneable
{
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public BaseDataType Clone() => Type switch
    {
        KnownDataType.Currency => ((CurrencyDataType)this).Clone(),
        KnownDataType.DateTime => ((DateTimeDataType)this).Clone(),
        KnownDataType.Numeric => ((NumericDataType)this).Clone(),
        KnownDataType.Percentage => ((PercentageDataType)this).Clone(),
        KnownDataType.Scientific => ((ScientificDataType)this).Clone(),
        _ => ((TextDataType)this).Clone()
    };
}
