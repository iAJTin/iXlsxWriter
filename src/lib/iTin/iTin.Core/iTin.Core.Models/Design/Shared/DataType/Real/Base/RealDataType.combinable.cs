
namespace iTin.Core.Models.Design;

public partial class RealDataType : ICombinable<RealDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<RealDataType>.Combine(RealDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(RealDataType reference)
    {
        if (Decimals.Equals(DefaultDecimals))
        {
            Decimals = reference.Decimals;
        }
    }
}
