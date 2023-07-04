
namespace iTin.Core.Models.Design;

public partial class CurrencyDataType : ICombinable<CurrencyDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<CurrencyDataType>.Combine(CurrencyDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(CurrencyDataType reference)
    {
        base.Combine(reference);

        if (Locale.Equals(LocaleDefault))
        {
            Locale = reference.Locale;
        }
    }
}
