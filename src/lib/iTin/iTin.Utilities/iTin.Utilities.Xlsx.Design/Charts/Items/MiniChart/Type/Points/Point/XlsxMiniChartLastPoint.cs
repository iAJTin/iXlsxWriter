
using System;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic minichart data point.
/// </summary>
public partial class XlsxMiniChartLastPoint : ICombinable<XlsxMiniChartLastPoint>, ICloneable
{
    #region interfaces

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxMiniChartLastPoint Clone() => (XlsxMiniChartLastPoint)MemberwiseClone();

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxMiniChartLastPoint reference)
    {
        base.Combine(reference);
    }

    #endregion
}
