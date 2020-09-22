
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartColumnPoints : ICombinable<XlsxMiniChartColumnPoints>
    {
        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxMiniChartColumnPoints>.Combine(XlsxMiniChartColumnPoints): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChartColumnPoints>.Combine(XlsxMiniChartColumnPoints reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartColumnPoints) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartColumnPoints Clone() => (XlsxMiniChartColumnPoints)MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartColumnTypeOptions): Apply specified options to this minichart
        ///// <summary>
        ///// Apply specified options to this minichart.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartColumnPointsOptions options)
        //{
        //    base.ApplyOptions(options);
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartColumnPoints): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxMiniChartColumnPoints reference)
        {
            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
