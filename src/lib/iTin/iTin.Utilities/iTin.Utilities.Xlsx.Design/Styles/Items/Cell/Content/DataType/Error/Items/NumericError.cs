
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// A Specialization of <see cref="BaseError"/> class.
    /// Which acts as the base class of error structures for numerical data.
    /// </summary>
    /// <remarks>
    ///   <para>The following table shows the different data types error structures.</para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="PercentageError"/></term>
    ///       <description>Represents the error structure for percentage data type.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="ScientificError"/></term>
    ///       <description>Represents the error structure for scientific data type.</description>
    ///     </item>
    ///   </list>
    /// </remarks>        
    public partial class NumericError : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultValue = 0.0f;
        #endregion

        #region constructor/s

        #region [public] NumericError(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericError" /> class.
        /// </summary>
        public NumericError()
        {
            Value = DefaultValue;
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

        #region [public] (float) Value: Gets or sets preferred default value when occurs an error
        /// <summary>
        /// Gets or sets preferred default value when occurs an error. The default is <b>0.0</b>.
        /// </summary>
        /// <value>
        /// Preferred default value when occurs an error.
        /// </value>
        [XmlAttribute]
        [JsonProperty("value")]
        [DefaultValue(DefaultValue)]
        public float Value { get; set; }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance is default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Value.Equals(DefaultValue);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (NumericError) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new NumericError Clone()
        {
            var numericErrorCloned = (NumericError)MemberwiseClone();
            numericErrorCloned.Comment = Comment.Clone();
            numericErrorCloned.Properties = Properties.Clone();

            return numericErrorCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(NumericError): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(NumericError reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Value.Equals(DefaultValue))
            {
                Value = reference.Value;
            }

            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
