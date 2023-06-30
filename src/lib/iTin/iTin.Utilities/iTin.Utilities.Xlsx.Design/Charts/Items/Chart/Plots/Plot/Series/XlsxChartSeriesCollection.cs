
using System;
using System.Linq;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines plots collection settings. Allows to set the chart plot.
    /// </summary>
    public partial class XlsxChartSeriesCollection : ICloneable
    {
        #region constructor/s

        #region [public] XlsxChartSeriesCollection(): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartSeriesCollection"/> class.
        /// </summary>
        public XlsxChartSeriesCollection() : base(null)
        {
        }
        #endregion

        #region [public] XlsxChartSeriesCollection(XlsxChartPlot): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartSeriesCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public XlsxChartSeriesCollection(XlsxChartPlot parent) : base(parent)
        {
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
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

        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (void) SetOwner(XlsxChartSerie): Sets this collection as the owner of the specified item
        /// <inheritdoc/>
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxChartSerie item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartSeriesCollection) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartSeriesCollection Clone()
        {
            var cloned = new XlsxChartSeriesCollection(Parent)
            {
                Properties = Properties.Clone()
            };

            foreach (var serie in this)
            {
                cloned.Add(serie.Clone());
            }

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxChartSeriesCollection): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxChartSeriesCollection reference)
        {
            if (reference == null)
            {
                return;
            }

            var hasElements = this.Any();
            if (!hasElements)
            {
                foreach (var referenceSerie in reference)
                {
                    var serie = referenceSerie.Clone();
                    serie.SetOwner(this);
                    Add(serie);
                }
            }
            //else
            //{
            //    foreach (var plot in this)
            //    {
            //        var refPlot = reference.GetBy(plot.Name);
            //        if (refPlot != null)
            //        {
            //            plot.Combine(refPlot);
            //        }
            //    }

            //    foreach (var referencePlot in reference)
            //    {
            //        var plot = GetBy(referencePlot.Name);
            //        if (plot != null)
            //        {
            //            continue;
            //        }

            //        var newPlot = referencePlot.Clone();
            //        newPlot.SetOwner(this);
            //        Add(newPlot);
            //    }
            //}
        }
        #endregion

        #endregion
    }
}
