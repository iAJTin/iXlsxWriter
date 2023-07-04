
namespace iTin.Core.Models.Design;

public partial class DateTimeError : ICombinable<DateTimeError>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<DateTimeError>.Combine(DateTimeError reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(DateTimeError reference)
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
