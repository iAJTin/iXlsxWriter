
namespace iTin.Core.Models.Design;

public partial class ScientificDataType : ICombinable<ScientificDataType>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<ScientificDataType>.Combine(ScientificDataType reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(ScientificDataType reference)
    {
        base.Combine(reference);

        Error.Combine(reference.Error);
    }
}
