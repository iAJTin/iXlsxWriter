
using System;

using iTin.Core.Helpers;

namespace iTin.Core.Models.Design.Charting;

public partial class ChartsCollection : ICharts
{
    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public ChartsCollection Clone() => CopierHelper.DeepCopy(this);
}
