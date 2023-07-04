
namespace iTin.Core.Models.Design;

public partial class PercentageDataType : ICombinable<PercentageDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<PercentageDataType>.Combine(PercentageDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(PercentageDataType reference)
    {
        base.Combine(reference);

        Error.Combine(reference.Error);
    }
}
