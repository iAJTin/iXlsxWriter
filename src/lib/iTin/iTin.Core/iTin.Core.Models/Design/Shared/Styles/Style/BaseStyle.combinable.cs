
using System;

namespace iTin.Core.Models.Design.Styles;

public partial class BaseStyle
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IStyle>.Combine(IStyle reference) => Combine((BaseStyle)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public void Combine(BaseStyle reference) => Combine(reference, true);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    /// <param name="forceInherits">Reference style</param>
    public virtual void Combine(BaseStyle reference, bool forceInherits)
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
                reference.Combine((BaseStyle)inheritStyle);
            }
        }

        Borders.Combine(reference.Borders);
        Content.Combine(reference.Content);
    }
}
