
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Represents the visual setting for axes of a chart. Includes information of primary and secondary axes.
    /// </summary>
    public partial class XlsxChartAxes : ICombinable<XlsxChartAxes>, ICloneable, IParent
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxChartAxis _primary;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxChartAxis _secondary;
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

        #region (void) ICombinable<XlsxChartAxes>.Combine(XlsxChartAxes): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartAxes>.Combine(XlsxChartAxes reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxChartAxes) Default: Gets a default chart axes settings
        /// <summary>
        /// Returns a new instance containing default chart axes settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxes"/> reference containing the default chart axes settings.
        /// </value>
        public static XlsxChartAxes Default => new XlsxChartAxes();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) PrimarySpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool PrimarySpecified => !Primary.IsDefault;
        #endregion

        #region [public] (XlsxChart) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxChart Parent { get; private set; }
        #endregion

        #region [public] (bool) SecondarySpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool SecondarySpecified => !Secondary.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxChartAxis) Primary: Gets or sets a reference to information of primary axis
        /// <summary>
        /// Gets or sets a reference to information of primary axis. Includes information for the category and value axis.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxis"/> reference to information of primary axis.
        /// </value>
        [XmlElement]
        [JsonProperty("primary")]
        public XlsxChartAxis Primary
        {
            get
            {
                if (_primary == null)
                {
                    _primary = new XlsxChartAxis();
                }

                _primary.SetParent(this);

                return _primary;
            }
            set => _primary = value;
        }
        #endregion

        #region [public] (XlsxChartAxis) Secondary: Gets or sets a reference to information of secondary axis
        /// <summary>
        /// Gets or sets a reference to information of secondary axis. Includes information for the category and value axis.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxis"/> reference to information of secondary axis.
        /// </value>
        [XmlElement]
        [JsonProperty("secondary")]
        public XlsxChartAxis Secondary
        {
            get
            {
                if (_secondary == null)
                {
                    _secondary = new XlsxChartAxis();
                }

                _secondary.SetParent(this);

                return _secondary;
            }
            set => _secondary = value;
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
        public override bool IsDefault => base.IsDefault && Primary.IsDefault && Secondary.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartAxes) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartAxes Clone()
        {
            var cloned = (XlsxChartAxes)MemberwiseClone();
            cloned.Primary = Primary.Clone();
            cloned.Secondary = Secondary.Clone();
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

        #region [public] {virtual} (void) Combine(XlsxChartAxes): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxChartAxes reference)
        {
            if (reference == null)
            {
                return;
            }

            Primary.Combine(reference.Primary);
            Secondary.Combine(reference.Secondary);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxChart): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxChart reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
