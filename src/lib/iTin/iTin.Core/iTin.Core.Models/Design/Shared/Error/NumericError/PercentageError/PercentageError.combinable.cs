
namespace iTin.Core.Models.Design;

public partial class PercentageError : ICombinable<PercentageError>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<PercentageError>.Combine(PercentageError reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(PercentageError reference)
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
