
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="RealDataType"/> class.<br/>.
    /// Which acts as base class for the data types negative numbers with decimals .
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The following table shows the different numeric data field types.
    ///   </para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="NumberDataType"/></term>
    ///       <description>Represents number format, You can specify the number of decimal places that you want to use, whether you want to use a thousands separator, and how you want to display negative numbers.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="CurrencyDataType"/></term>
    ///       <description>Represents currency format. The currency symbol appears right next to the first digit. You can specify the number of decimal places that you want to use and how you want to display negative numbers.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class NumericDataType : ICloneable
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NegativeModel _negative;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NumericError _error;
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

        #region public readonly properties

        #region [public] (bool) ErrorSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ErrorSpecified => !Error.IsDefault;
        #endregion

        #region [public] (bool) NegativeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool NegativeSpecified => !Negative.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (NumericError) Error: Gets or sets a reference that contains numeric data type error settings
        /// <summary>
        /// Gets or sets a reference that contains numeric data type error settings.
        /// </summary>
        /// <value>
        /// Numeric data type error settings
        /// </value>
        [XmlElement]
        [JsonProperty("error")]
        public NumericError Error
        {
            get => _error ?? (_error = new NumericError());
            set => _error = value;
        }
        #endregion

        #region [public] (NegativeModel) Negative: Gets or sets a reference that contains the negative number format
        /// <summary>
        /// Gets or sets a reference that contains the negative number format.
        /// </summary>
        /// <value>
        /// Negative number format.
        /// </value>
        [XmlElement]
        [JsonProperty("negative")]
        public NegativeModel Negative
        {
            get => _negative ?? (_negative = new NegativeModel());
            set => _negative = value;
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Error.IsDefault &&
            Negative.IsDefault;
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (NumericDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new NumericDataType Clone()
        {
            var numericDataCloned = (NumericDataType)MemberwiseClone();
            numericDataCloned.Error = Error.Clone();
            numericDataCloned.Negative = Negative.Clone();
            numericDataCloned.Properties = Properties.Clone();

            return numericDataCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(NumericDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(NumericDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            Error.Combine(reference.Error);
            Negative.Combine(reference.Negative);
        }
        #endregion

        #endregion
    }
}
