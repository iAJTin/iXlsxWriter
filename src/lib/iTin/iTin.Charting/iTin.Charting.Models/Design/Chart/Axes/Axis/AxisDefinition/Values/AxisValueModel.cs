
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Options;

    /// <summary>
    /// Represents the visual setting the values of a axis.
    /// </summary>
    public partial class AxisValueModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultMinimun = 0.0f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultInterval = 10.0f;
        #endregion

        #region constructor/s

        #region [public] AxisValueModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.AxisValueModel" /> class.
        /// </summary>
        public AxisValueModel()
        {
            Interval = DefaultInterval;
            Minimun = DefaultMinimun;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #region public properties

        #region [public] (float?) Interval: Gets or sets the interval value of axis expressed in tenths of a second
        /// <summary>
        /// Gets or sets the interval value of axis expressed in tenths of a second. The default is <b>(10.0)</b>. 
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the interval value of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultInterval)]
        public float? Interval { get; set; }
        #endregion

        #region [public] (float?) Maximun: Gets or sets maximun value of axis expressed in tenths of a second
        /// <summary>
        /// Gets or sets maximun value of axis expressed in tenths of a second.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the maximun value of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public float? Maximun { get; set; }
        #endregion

        #region [public] (float?) Minimun: Gets or sets maximun value of axis expressed in tenths of a second
        /// <summary>
        /// Gets or sets maximun value of axis expressed in tenths of a second. The default is <b>(0.0)</b>. 
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the minimun value of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultMinimun)]
        public float? Minimun { get; set; }
        #endregion

        #region [public] (AxisDefinitionModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxisDefinitionModel Parent { get; private set; }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => Minimun.Equals(DefaultMinimun) && Interval.Equals(DefaultInterval);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(AxisValuesOptions): Apply specified options to this axis values
        /// <summary>
        /// Apply specified options to this axis values.
        /// </summary>
        public void ApplyOptions(AxisValuesOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Interval
            float? intervalOption = options.Interval;
            bool intervalHasValue = intervalOption.HasValue;
            if (intervalHasValue)
            {
                Interval = intervalOption.Value;
            }
            #endregion

            #region Maximun
            float? maximunOption = options.Maximun;
            bool maximunHasValue = maximunOption.HasValue;
            if (maximunHasValue)
            {
                Maximun = maximunOption.Value;
            }
            #endregion

            #region Minimun
            float? minimunOption = options.Minimun;
            bool minimunHasValue = minimunOption.HasValue;
            if (minimunHasValue)
            {
                Minimun = minimunOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] (AxisValueModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisValueModel Clone()
        {
            var cloned = (AxisValueModel)MemberwiseClone();
            cloned.SetParent(Parent);

            return cloned;
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current instance
        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(AxisDefinitionModel): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxisDefinitionModel reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
