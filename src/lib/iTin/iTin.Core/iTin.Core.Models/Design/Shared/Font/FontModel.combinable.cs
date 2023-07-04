
namespace iTin.Core.Models.Design;

public partial class FontModel : ICombinable<FontModel>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<FontModel>.Combine(FontModel reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(FontModel reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Bold.Equals(DefaultFontBold))
        {
            Bold = reference.Bold;
        }

        if (Color.Equals(DefaultFontColor))
        {
            Color = reference.Color;
        }

        if (Italic.Equals(DefaultFontItalic))
        {
            Italic = reference.Italic;
        }

        if (Name.Equals(DefaultFontName))
        {
            Name = reference.Name;
        }

        if (Size.Equals(DefaultFontSize))
        {
            Size = reference.Size;
        }

        if (Underline.Equals(DefaultFontUnderline))
        {
            Underline = reference.Underline;
        }
    }
}