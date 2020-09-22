
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br/>
    /// Which acts as the base class for data types with decimal numbers.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The following table shows the different data field types.
    ///   </para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="NumericDataType"/></term>
    ///       <description>Represents base class for the data types negative numbers with decimals.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="PercentageDataType"/></term>
    ///       <description>Displays the result with a percent sign (%). You can specify the number of decimal places to use.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="ScientificDataType"/></term>
    ///       <description>Displays a number in exponential notation, which replaces part of the number with E + n, where E (exponent) multiplies the preceding number by 10 to n. You can specify the number of decimal places you want to use.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class RealDataType : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultDecimals = 2;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _decimals;
        #endregion

        #region constructor/s

        #region [protected] RealDataType: Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="RealDataType"/> class.
        /// </summary>
        protected RealDataType()
        {
            Decimals = DefaultDecimals;
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

        #region public properties

        #region [public] (int) Decimals: Gets or sets number of decimal places
        /// <summary>
        /// Gets or sets number of decimal places. The default is <b>2</b>.
        /// </summary>
        /// <value>
        /// Number of decimal places.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than 0.</exception>
        [XmlAttribute]
        [JsonProperty("decimals")]
        [DefaultValue(DefaultDecimals)]
        public int Decimals
        {
            get => _decimals;
            set
            {
                SentinelHelper.ArgumentLessThan("value", value, 0);

                _decimals = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Decimals.Equals(DefaultDecimals);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (RealDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new RealDataType Clone()
        {
            var realDataTypeCloned = (RealDataType)MemberwiseClone();
            realDataTypeCloned.Properties = Properties.Clone();

            return realDataTypeCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(RealDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(RealDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Decimals.Equals(DefaultDecimals))
            {
                Decimals = reference.Decimals;
            }
        }
        #endregion

        #endregion
    }
}
