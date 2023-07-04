
namespace iTin.Core.Models.Design;

public partial class ScientificError : ICombinable<ScientificError>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<ScientificError>.Combine(ScientificError reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(ScientificError reference)
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
