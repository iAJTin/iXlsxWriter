
namespace OfficeOpenXml.Helpers
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml;

    using iTin.Core.Helpers;

    using Drawing.Chart;

    /// <summary>
    /// A Specialization of <see cref="XmlBaseHelper"/> class.<br/>
    /// Allows manipulate the underliying <b>XML</b> chart document.
    /// </summary>
    internal class XmlChartHelper : XmlBaseHelper
    {
        #region public constants
        /// <summary>
        /// A <see cref="System.String"/> than represents path to root element of list of charts.
        /// </summary>
        public const string ChartSpaceRootNode = "c:chartSpace";

        /// <summary>
        /// A <see cref="System.String"/> than represents path to root element of Chart.
        /// </summary>
        public const string ChartRootNode = "c:chartSpace/c:chart";

        /// <summary>
        /// A <see cref="System.String"/> than represents path to chart legend element of Chart.
        /// </summary>
        public const string ChartLegendRootNode = "c:chartSpace/c:chart/c:legend";

        /// <summary>
        /// A <see cref="System.String"/> than represents path to chart title element of Chart.
        /// </summary>
        public const string ChartTitleRootNode = "c:chartSpace/c:chart/c:title";

        /// <summary>
        /// A <see cref="System.String"/> than represents path to plot chart element of Chart.
        /// </summary>
        public const string ChartPlotAreaRootNode = "c:chartSpace/c:chart/c:plotArea";

        /// <summary>
        /// A <see cref="System.String"/> than represents path to area chart element of Chart.
        /// </summary>
        public const string ChartPlotAreaChartAreaRootNode = "c:chartSpace/c:chart/c:plotArea/c:areaChart";

        /// <summary>
        /// A <see cref="System.String"/> than represents main namespace.
        /// </summary>
        public const string MainDrawingmlNamespace = "http://schemas.openxmlformats.org/drawingml/2006/main";

        /// <summary>
        /// A <see cref="System.String"/> than represents chart namespace.
        /// </summary>
        public const string ChartDrawingmlNamespace = "http://schemas.openxmlformats.org/drawingml/2006/chart";
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XmlNamespaceManager _manager;
        #endregion

        #region private new static members
        private new static readonly XmlChartHelper Instance = new XmlChartHelper();
        #endregion

        #region protected override methods

        #region [protected] {override} (void) GetNamespaceManager(): Resolves the namespace manager to use for this XML document
        /// <summary>
        /// Resolves the namespace manager to use for this <b>XML</b> document.
        /// </summary>
        protected override void ResolveNamespaceManager()
        {
            var manager = new XmlNamespaceManager(XmlDocument.NameTable);
            manager.AddNamespace("a", MainDrawingmlNamespace);
            manager.AddNamespace("c", ChartDrawingmlNamespace);

            NamespaceManager = manager;
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XmlNode) FromKnownChartElement(KnownChartElement): Returns a value than represents a known node
        /// <summary>
        /// Returns a value than represents a known node.
        /// </summary>
        /// <param name="element">A <see cref="KnownChartElement"/> value.</param>
        /// <returns>
        /// <see cref="XmlNode"/> reference that contains <c>Xml</c> node.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public XmlNode FromKnownChartElement(KnownChartElement element)
        {
            SentinelHelper.IsEnumValid(element);

            XmlNode knownRootNode = null;
            switch (element)
            {
                case KnownChartElement.Self:
                    knownRootNode = GetXmlNode(ChartSpaceRootNode);
                    break;

                case KnownChartElement.Legend:
                    knownRootNode = GetXmlNode(ChartLegendRootNode);
                    break;

                case KnownChartElement.PlotArea:
                    knownRootNode = GetXmlNode(ChartPlotAreaRootNode);
                    break;

                case KnownChartElement.ChartTitle:
                    knownRootNode = GetXmlNode(ChartTitleRootNode);
                    break;

                case KnownChartElement.PrimaryCategoryAxis:
                    knownRootNode = GetElementsByTagName("c:catAx").ToList()[0];
                    break;

                case KnownChartElement.PrimaryValueAxis:
                    knownRootNode = GetElementsByTagName("c:valAx").ToList()[0];
                    break;

                case KnownChartElement.SecondaryCategoryAxis:
                    var catAxisXmlList = GetElementsByTagName("c:catAx").ToList();

                    SentinelHelper.IsTrue(catAxisXmlList.Count <= 1, "Error the secondary axis does not exist");
                    knownRootNode = catAxisXmlList[1];
                    break;

                case KnownChartElement.SecondaryValueAxis:
                    var valAxisXmlList = GetElementsByTagName("c:valAx").ToList();

                    SentinelHelper.IsTrue(valAxisXmlList.Count <= 1, "Error the secondary axis does not exist");
                    knownRootNode = valAxisXmlList[1];
                    break;

                case KnownChartElement.PrimaryCategoryAxisTitle:
                    knownRootNode = GetXmlNode(GetElementsByTagName("c:catAx").ToList()[0], "c:title");
                    break;

                case KnownChartElement.PrimaryValueAxisTitle:
                    knownRootNode = GetXmlNode(GetElementsByTagName("c:valAx").ToList()[0], "c:title");
                    break;

                case KnownChartElement.SecondaryCategoryAxisTitle:
                    var catAxisXmlList1 = GetElementsByTagName("c:catAx").ToList();

                    SentinelHelper.IsTrue(catAxisXmlList1.Count <= 1, "Error the secondary axis does not exist");
                    knownRootNode = GetXmlNode(catAxisXmlList1[1], "c:title");
                    break;

                case KnownChartElement.SecondaryValueAxisTitle:
                    var valAxisXmlList2 = GetElementsByTagName("c:valAx").ToList();

                    SentinelHelper.IsTrue(valAxisXmlList2.Count <= 1, "Error the secondary axis does not exist");
                    knownRootNode = GetXmlNode(valAxisXmlList2[1], "c:title");
                    break;
            }

            return knownRootNode;
        }
        #endregion

        #endregion
    }
}
