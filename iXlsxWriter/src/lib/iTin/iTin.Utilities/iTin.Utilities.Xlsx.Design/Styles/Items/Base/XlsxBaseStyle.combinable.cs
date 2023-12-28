
using iTin.Core.Models.Design;

using System;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="IXlsxStyle"/> interface.<br/>
/// Defines a generic <b>xlsx</b> style.
/// </summary>
public partial class XlsxBaseStyle : ICombinable<XlsxBaseStyle>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IStyle>.Combine(IStyle reference) => Combine((XlsxBaseStyle)reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IXlsxStyle>.Combine(IXlsxStyle reference) => Combine((XlsxBaseStyle)reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<XlsxBaseStyle>.Combine(XlsxBaseStyle reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public void Combine(XlsxBaseStyle reference) => Combine(reference, true);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    /// <param name="forceInherits">Reference style</param>
    public virtual void Combine(XlsxBaseStyle reference, bool forceInherits)
    {
        if (reference == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(Name))
        {
            throw new NullReferenceException("Primero asignar un nombre de estilo antes de combinar");
        }

        if (forceInherits)
        {
            var hasInheritStyle = !string.IsNullOrEmpty(reference.Inherits);
            if (hasInheritStyle)
            {
                var inheritStyle = reference.TryGetInheritStyle();
                reference.Combine((XlsxBaseStyle)inheritStyle);
            }
        }

        Borders.Combine(reference.Borders);
        Content.Combine(reference.Content);
    }
}
