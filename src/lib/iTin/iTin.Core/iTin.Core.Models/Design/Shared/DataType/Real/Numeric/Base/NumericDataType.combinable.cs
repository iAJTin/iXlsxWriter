
namespace iTin.Core.Models.Design;

public partial class NumericDataType : ICombinable<NumericDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<NumericDataType>.Combine(NumericDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(NumericDataType reference)
    {
        base.Combine(reference);

        Error.Combine(reference.Error);
        Negative.Combine(reference.Negative);
    }
}
