
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartColumnPoints : ICombinable<XlsxMiniChartColumnPoints>
{
    #region interfaces

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartColumnPoints>.Combine(XlsxMiniChartColumnPoints reference) => Combine(reference);

    #endregion

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxMiniChartColumnPoints Clone() => (XlsxMiniChartColumnPoints)MemberwiseClone();

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartColumnPointsOptions options)
    //{
    //    base.ApplyOptions(options);
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartColumnPoints reference)
    {
        base.Combine(reference);
    }

    #endregion
}
