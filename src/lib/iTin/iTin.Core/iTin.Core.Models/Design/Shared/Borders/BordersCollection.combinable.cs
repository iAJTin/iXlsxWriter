
using System.Linq;

namespace iTin.Core.Models.Design;

public partial class BordersCollection
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IBorders>.Combine(IBorders reference) => Combine((BordersCollection)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(BordersCollection reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referenceBorder in reference)
            {
                var border = referenceBorder.Clone();
                border.SetOwner(this);
                Add(border);
            }
        }
        else
        {
            foreach (var border in this)
            {
                var refborder = reference.GetBy(border.Position);
                if (refborder != null)
                {
                    border.Combine(refborder);
                }
            }

            foreach (var referenceBorder in reference)
            {
                var border = GetBy(referenceBorder.Position);
                if (border != null)
                {
                    continue;
                }

                var newBorder = referenceBorder.Clone();
                newBorder.SetOwner(this);
                Add(newBorder);
            }
        }
    }
}
