
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    ///Represents the visual setting the labels of a axis.
    /// </summary>
    public partial class XlsxChartAxisDefinitionMarks : ICombinable<XlsxChartAxisDefinitionMarks>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const TickMarkStyle DefaultMajor = TickMarkStyle.Cross;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const TickMarkStyle DefaultMinor = TickMarkStyle.Cross;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TickMarkStyle _major;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TickMarkStyle _minor;
        #endregion

        #region constructor/s

        #region [public] XlsxChartAxisDefinitionMarks(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartAxisDefinitionMarks"/> class.
        /// </summary>
        public XlsxChartAxisDefinitionMarks()
        {
            Major = DefaultMajor;
            Minor = DefaultMinor;
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

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxChartAxisDefinitionMarks>.Combine(XlsxChartAxisDefinitionMarks): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartAxisDefinitionMarks>.Combine(XlsxChartAxisDefinitionMarks reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxChartAxisDefinitionMarks) Default: Returns a new instance containing default chart axis marks definition settings
        /// <summary>
        /// Returns a new instance containing default chart axis marks definition settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxisDefinitionMarks"/> reference containing the default chart axis marks definition settings.
        /// </value>
        public static XlsxChartAxisDefinitionMarks Default => new XlsxChartAxisDefinitionMarks();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxChartAxisDefinition) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxChartAxisDefinition Parent { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (TickMarkStyle) Major: Gets or sets the preferred position of major tick marks for an axis
        /// <summary>
        /// Gets or sets the preferred position of major tick marks for an axis. The default is <see cref="TickMarkStyle.Cross"/>.
        /// </summary>
        /// <value>
        /// Preferred position of major tick marks for an axis.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultMajor)]
        public TickMarkStyle Major
        {
            get => _major;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _major = value;
            }
        }
        #endregion

        #region [public] (TickMarkStyle) Minor: Gets or sets the preferred position of minor tick marks for an axis
        /// <summary>
        /// Gets or sets the preferred position of minor tick marks for an axis. The default is <see cref="TickMarkStyle.Cross"/>.
        /// </summary>
        /// <value>
        /// Preferred position of minor tick marks for an axis.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultMinor)]
        public TickMarkStyle Minor
        {
            get => _minor;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _minor = value;
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
        public override bool IsDefault =>
            base.IsDefault &&
            Major.Equals(DefaultMajor) &&
            Minor.Equals(DefaultMinor);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartAxisDefinitionMarks) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartAxisDefinitionMarks Clone()
        {
            var cloned = (XlsxChartAxisDefinitionMarks)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxChartAxisDefinitionMarksOptions): Apply specified options to this axes
        ///// <summary>
        ///// Apply specified options to this axes.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxChartAxisDefinitionMarksOptions options)
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

        #region [public] {virtual} (void) Combine(XlsxChartAxisDefinitionMarks): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxChartAxisDefinitionMarks reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Major.Equals(DefaultMajor))
            {
                Major = reference.Major;
            }

            if (Minor.Equals(DefaultMinor))
            {
                Minor = reference.Minor;
            }
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxChartAxisDefinition): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChartAxisDefinition"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxChartAxisDefinition reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
