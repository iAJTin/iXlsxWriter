
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design;

public partial class XlsxSettings : ICombinable<XlsxSettings>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxSettings>.Combine(XlsxSettings reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxSettings reference)
    {
        if (reference == null)
        {
            return;
        }

        reference.SheetsSettings.Combine(reference.SheetsSettings);
        reference.DocumentSettings.Combine(reference.DocumentSettings);
    }
}
