
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartWinLossPoints : ICombinable<XlsxMiniChartWinLossPoints>
    {
        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxMiniChartWinLossPoints>.Combine(XlsxMiniChartWinLossPoints): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChartWinLossPoints>.Combine(XlsxMiniChartWinLossPoints reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartWinLossSerie) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartWinLossPoints Clone() => (XlsxMiniChartWinLossPoints)MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartWinLossPointsOptions): Apply specified options to this minichart
        ///// <summary>
        ///// Apply specified options to this minichart.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartWinLossPointsOptions options)
        //{
        //    base.ApplyOptions(options);
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartWinLossPoints): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxMiniChartWinLossPoints reference)
        {
            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
