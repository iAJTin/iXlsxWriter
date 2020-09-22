
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic axis chart. Includes information for the category and value axes.
    /// </summary>
    public partial class XlsxChartAxis : ICombinable<XlsxChartAxis>, ICloneable, IParent
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxChartAxisDefinition _values;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxChartAxisDefinition _category;
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

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxChartAxes>.Combine(XlsxChartAxis): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartAxis>.Combine(XlsxChartAxis reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxChartAxis) Default: Gets a default chart axis settings
        /// <summary>
        /// Gets a default chart axis settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxis"/> reference containing the default chart axis settings.
        /// </value>
        public static XlsxChartAxis Default => new XlsxChartAxis();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) CategorySpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool CategorySpecified => !Category.IsDefault;
        #endregion

        #region [public] (XlsxChartAxes) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxChartAxes Parent { get; private set; }
        #endregion

        #region [public] (bool) ValuesSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ValuesSpecified => !Values.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxChartAxisDefinition) Category: Gets or sets a reference that contains the visual setting of category axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of category axis. Allows you to configure the axis title, the axis labels, axis marks and axis values.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxisDefinition"/> reference that contains the visual setting of category axis.
        /// </value>
        [XmlElement]
        [JsonProperty("category")]
        public XlsxChartAxisDefinition Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new XlsxChartAxisDefinition();
                }

                _category.SetParent(this);

                return _category;
            }
            set => _category = value;
        }
        #endregion

        #region [public] (XlsxChartAxisDefinition) Values: Gets or sets a reference that contains the visual setting of of values axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of of values axis. Allows you to configure the axis title, the axis labels, axis marks and axis values.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxisDefinition"/> reference that contains the visual setting of of values axis.
        /// </value>
        [XmlElement]
        [JsonProperty("values")]
        public XlsxChartAxisDefinition Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new XlsxChartAxisDefinition();
                }

                _values.SetParent(this);

                return _values;
            }
            set => _values = value;
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
        public override bool IsDefault =>
            base.IsDefault && 
            Values.IsDefault && 
            Category.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartAxis) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartAxis Clone()
        {
            var cloned = (XlsxChartAxis)MemberwiseClone();
            cloned.Values = Values.Clone();
            cloned.Category = Category.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartAxesOptions): Apply specified options to this axes
        ///// <summary>
        ///// Apply specified options to this axes.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartAxesOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region Horizontal
        //    Horizontal.ApplyOptions(options.Horizontal);
        //    #endregion

        //    #region Vertical
        //    Vertical.ApplyOptions(options.Vertical);
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxChartAxis): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxChartAxis reference)
        {
            if (reference == null)
            {
                return;
            }

            Values.Combine(reference.Values);
            Category.Combine(reference.Category);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxChartAxes): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxChartAxes reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
