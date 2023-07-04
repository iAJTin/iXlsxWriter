
namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic interface that defines a generic options
/// </summary>
public interface IOptions<in T> where T : class
{
    /// <summary>
    /// Apply specified options to an existing instance.
    /// </summary>
    /// <param name="reference">Target Reference</param>
    void ApplyOptions(T reference);
}
