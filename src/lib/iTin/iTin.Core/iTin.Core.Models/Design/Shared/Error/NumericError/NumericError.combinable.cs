
namespace iTin.Core.Models.Design;

public partial class NumericError : ICombinable<NumericError>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<NumericError>.Combine(NumericError reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(NumericError reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Value.Equals(DefaultValue))
        {
            Value = reference.Value;
        }

        base.Combine(reference);
    }
}
