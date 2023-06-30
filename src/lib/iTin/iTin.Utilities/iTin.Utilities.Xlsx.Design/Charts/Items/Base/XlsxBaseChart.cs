
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Charting;
using iTin.Core.Models.Design.Enums;

using iTinIO = iTin.Core.IO;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// A Specialization of <see cref="IXlsxChart"/> interface.<br/>
    /// Defines a generic <b>xlsx</b> chart.
    /// </summary>
    public partial class XlsxBaseChart : IXlsxChart, ICombinable<XlsxBaseChart>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;
        #endregion

        #region constructor/s

        #region [protected] XlsxBaseChart(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxBaseChart"/> class.
        /// </summary>
        protected XlsxBaseChart()
        {
            Show = DefaultShow;
            Name = string.Empty;
        }
        #endregion

        #endregion

        #region interfaces

        #region IChart

        #region explicit

        #region (bool) IChart.IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        bool IChart.IsDefault => IsDefault;
        #endregion

        #region (ICharts) IChart.Owner: Sets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="IChart"/>.
        /// </summary>
        /// <value>
        /// The <see cref="ICharts"/> that owns this <see cref="IChart"/>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ICharts IChart.Owner => Owner;
        #endregion

        #region (string) IChart.Name: Gets or sets the name of the chart
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        /// <value>
        /// The name of the chart.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string IChart.Name { get => Name; set => Name = value; }
        #endregion

        #region (YesNo) IChart.Show: Gets or sets a value that determines whether to display the border
        /// <summary>
        /// Gets or sets a value that determines whether to display the chart. The default is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if display the chart; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        YesNo IChart.Show { get => Show; set => Show = value; }
        #endregion

        #region (void) IChart.SetOwner(ICharts): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="IChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        void IChart.SetOwner(ICharts reference) => SetOwner((IXlsxCharts)reference);
        #endregion

        #endregion

        #endregion

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

        #region IXlsxChart

        #region explicit

        #region (IXlsxCharts) IXlsxChart.Owner: Sets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IXlsxCharts"/> that owns this <see cref="IXlsxChart"/>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IXlsxCharts IXlsxChart.Owner => Owner;
        #endregion

        #region (void) IXlsxChart.SetOwner(IXlsxCharts): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        void IXlsxChart.SetOwner(IXlsxCharts reference) => SetOwner(reference);
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (IXlsxCharts) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IXlsxCharts"/> that owns this <see cref="IXlsxChart"/>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public IXlsxCharts Owner { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Name: Gets or sets the name of the chart
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        /// <value>
        /// The name of the chart.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether to display the border
        /// <summary>
        /// Gets or sets a value that determines whether to display the chart. The default is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if display the chart; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        public YesNo Show
        {
            get => _show;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _show = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Show.Equals(DefaultShow);
        #endregion

        #endregion

        #endregion

        #region ICombinable<IChart>

        #region explicit

        #region (object) ICombinable<IChart>.Combine(IChart): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        void ICombinable<IChart>.Combine(IChart reference) => Combine((XlsxBaseChart)reference);
        #endregion

        #endregion

        #endregion

        #region ICombinable<IXlsxChart>

        #region explicit

        #region (object) ICombinable<IXlsxChart>.Combine(IXlsxChart): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        void ICombinable<IXlsxChart>.Combine(IXlsxChart reference) => Combine((XlsxBaseChart)reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxBaseChart) Default: Gets a default chart
        /// <summary>
        /// Gets a default chart.
        /// </summary>
        /// <value>
        /// A default chart.
        /// </value>
        public static XlsxBaseChart Default => new XlsxBaseChart();
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (string) GenerateRandomChartName(): Returns a random graph name
        /// <summary>
        /// Returns a random graph name.
        /// </summary>
        /// <returns>
        /// A new graph name.
        /// </returns>
        public static string GenerateRandomChartName() 
            => System.IO.Path.ChangeExtension(iTinIO.File.GetUniqueTempRandomFile().Segments.Last(), string.Empty).Replace(".", string.Empty);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBaseChart) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBaseChart Clone()
        {
            var cloned = (XlsxBaseChart)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxBaseChart): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxBaseChart reference)
        {
            if (reference == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new NullReferenceException("Primero asignar un nombre al gráfico antes de combinar");
            }

            //Borders.Combine(reference.Borders);
            //Content.Combine(reference.Content);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(IXlsxCharts): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(IXlsxCharts reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
