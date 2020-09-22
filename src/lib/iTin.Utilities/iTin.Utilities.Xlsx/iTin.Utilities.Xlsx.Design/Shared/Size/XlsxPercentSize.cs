
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseSize"/> class.<br/>
    /// Represents a size by percentual value.
    /// </summary>
    public partial class XlsxPercentSize
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultPercent = 100.0f;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _percent;
        #endregion

        #region constructor/s

        #region [public] XlsxPercentSize(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxPercentSize"/> class.
        /// </summary>
        public XlsxPercentSize()
        {
            Value = DefaultPercent;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (int) Value: Gets or sets the preferred percent value
        /// <summary>
        /// Gets or sets the preferred percent value, expresed in %. The default value is <b>100.0</b>.
        /// </summary>
        /// <value>
        /// Preferred percent value
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
        [XmlAttribute]
        [JsonProperty("value")]
        [DefaultValue(DefaultPercent)]
        public float Value
        {
            get => _percent;
            set
            {
                SentinelHelper.ArgumentOutOfRange("Value", value, 0.0f, 100.0f, "The value must be between 0 and 100");

                _percent = value;
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
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Value.Equals(DefaultPercent);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxPercentSize) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxPercentSize Clone()
        {
            var cloned = (XlsxPercentSize)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
