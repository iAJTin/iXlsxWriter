
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Represents the visual setting of chart legend. Includes visibility, location, border and font.
    /// </summary>
    public partial class XlsxChartLegend : ICombinable<XlsxChartLegend>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const LegendLocation DefaultLocation = LegendLocation.Right;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxBorder _border;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LegendLocation _location;
        #endregion

        #region constructor/s

        #region [public] XlsxChartLegend(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartLegend"/> class.
        /// </summary>
        public XlsxChartLegend()
        {
            Show = DefaultShow;
            Location = DefaultLocation;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxChartLegend>.Combine(XlsxChartLegend): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartLegend>.Combine(XlsxChartLegend reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxChartLegend) Default: Gets default chart legend configuration
        /// <summary>
        /// Gets default chart legend configuration.
        /// </summary>
        /// <value>
        /// Default chart legend configuration.
        /// </value>
        public static XlsxChartLegend Default => new XlsxChartLegend();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) BorderSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool BorderSpecified => !Border.IsDefault;
        #endregion

        #region [public] (bool) FontSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool FontSpecified => !Font.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxBorder) Border: Gets or sets a reference that contains the visual setting of legend border
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of legend border.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBorder" /> reference that contains the visual setting of legend border.          
        /// </value>
        [XmlElement]
        [JsonProperty("border")]
        public XlsxBorder Border
        {
            get => _border ?? (_border = XlsxBorder.Default);
            set => _border = value;
        }
        #endregion

        #region [public] (FontModel) Font: Gets or sets the font model
        /// <summary>
        /// Gets or sets the font model.
        /// </summary>
        /// <value>
        /// Reference that contains the definition of a font.            
        /// </value>
        [XmlElement]
        [JsonProperty("font")]
        public FontModel Font
        {
            get => _font ?? (_font = FontModel.DefaultFont);
            set => _font = value;
        }
        #endregion

        #region [public] (LegendLocation) Location: Gets or sets preferred location for chart legend
        /// <summary>
        /// Gets or sets preferred location for chart legend. The default is <see cref="LegendLocation.Right"/>.
        /// </summary>
        /// <value>
        /// Preferred location for chart legend.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("location")]
        [DefaultValue(DefaultLocation)]
        public LegendLocation Location
        {
            get => _location;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _location = value;
            }
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays legend
        /// <summary>
        /// Gets or sets a value that determines whether displays legend. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if display legend; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("show")]
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

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool IsDefault =>
            base.IsDefault &&
            Font.IsDefault &&
            Border.IsDefault &&
            Show.Equals(DefaultShow) &&
            Location.Equals(DefaultLocation);
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxChartLegendOptions): Apply specified options to this style
        ///// <summary>
        ///// Apply specified options to this style.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxChartLegendOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region Content
        //    Content.ApplyOptions(options.Content);
        //    #endregion

        //    #region Font
        //    Font.ApplyOptions(options.Font);
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxChartLegend): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxChartLegend reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Location.Equals(DefaultLocation))
            {
                Location = reference.Location;
            }

            Font.Combine(reference.Font);
            Border.Combine(reference.Border);
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] (XlsxChartLegend) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartLegend Clone()
        {
            var cloned = (XlsxChartLegend) MemberwiseClone();
            cloned.Font = Font.Clone();
            cloned.Border = Border.Clone();
            cloned.Properties = Properties.Clone();
            
            return cloned;
        }
        #endregion

        #endregion
    }
}
