﻿
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
    public partial class XlsxChartAxisDefinitionValues : ICombinable<XlsxChartAxisDefinitionValues>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultMaximum = "Autodetect";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultMinimum = "Autodetect";
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _maximum;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _minimum;
        #endregion

        #region constructor/s

        #region [public] XlsxChartAxisDefinitionValues(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartAxisDefinitionValues"/> class.
        /// </summary>
        public XlsxChartAxisDefinitionValues()
        {
            _maximum = DefaultMaximum;
            _minimum = DefaultMinimum;
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

        #region (void) ICombinable<XlsxChartAxisDefinitionValues>.Combine(XlsxChartAxisDefinitionValues): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartAxisDefinitionValues>.Combine(XlsxChartAxisDefinitionValues reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxChartAxisDefinitionValues) Default: Returns a new instance containing default chart axis values definition settings
        /// <summary>
        /// Returns a new instance containing default chart axis values definition settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxisDefinitionValues"/> reference containing the default chart axis values definition settings.
        /// </value>
        public static XlsxChartAxisDefinitionValues Default => new XlsxChartAxisDefinitionValues();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) HasMaximumValue: Gets a value that indicates whether the axis maximum value is the default value
        /// <summary>
        /// Gets a value that indicates whether the axis maximum value is the default value.
        /// </summary>
        /// <value>
        /// <b>true</b> if the axis maximum value is the default value; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public bool HasMaximumValue => !Maximum.Equals(DefaultMaximum);
        #endregion

        #region [public] (bool) HasMinimumValue: Gets a value that indicates whether the axis minimum value is the default value
        /// <summary>
        /// Gets a value that indicates whether the axis minimum value is the default value.
        /// </summary>
        /// <value>
        /// <b>true</b> if the axis minimum value is the default value; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public bool HasMinimumValue => !Minimum.Equals(DefaultMinimum);
        #endregion

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

        #region [public] (string) Maximum: Gets or sets maximum value of axis
        /// <summary>
        /// Gets or sets maximum value of axis. The default is <b>Autodetect</b>. 
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the maximum value of axis. Accepts only numbers in floating point. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("maximum")]
        [DefaultValue(DefaultMaximum)]
        public string Maximum
        {
            get => _maximum;
            set
            {
                if (value.Equals(DefaultMaximum))
                {
                    return;
                }

                var parseOk = float.TryParse(value, out _);
                SentinelHelper.IsFalse(parseOk, "Error value not valid");

                _maximum = value;
            }
        }
        #endregion

        #region [public] (string) Minimum: Gets or sets minimun value of axis
        /// <summary>
        /// Gets or sets minimum value of axis. The default is <b>Autodetect</b>. 
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the minimum value of axis. Accepts only numbers in floating point.
        /// </value>
        [XmlAttribute]
        [JsonProperty("minimum")]
        [DefaultValue(DefaultMinimum)]
        public string Minimum
        {
            get => _minimum;
            set
            {
                if (value.Equals(DefaultMinimum))
                {
                    return;
                }

                var parseOk = float.TryParse(value, out _);
                SentinelHelper.IsFalse(parseOk, "Error value not valid");

                _minimum = value;
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
            Maximum.Equals(DefaultMaximum) &&
            Minimum.Equals(DefaultMinimum);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartAxisDefinitionValues) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartAxisDefinitionValues Clone()
        {
            var cloned = (XlsxChartAxisDefinitionValues)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxChartAxisDefinitionValuesOptions): Apply specified options to this axes
        ///// <summary>
        ///// Apply specified options to this axes.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxChartAxisDefinitionValuesOptions options)
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

        #region [public] {virtual} (void) Combine(XlsxChartAxisDefinitionValues): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxChartAxisDefinitionValues reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Maximum.Equals(DefaultMaximum))
            {
                Maximum = reference.Maximum;
            }

            if (Minimum.Equals(DefaultMinimum))
            {
                Minimum = reference.Minimum;
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
