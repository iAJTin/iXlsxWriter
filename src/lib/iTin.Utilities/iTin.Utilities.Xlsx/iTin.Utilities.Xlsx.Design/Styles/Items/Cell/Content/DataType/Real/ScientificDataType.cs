
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="RealDataType"/> class.<br/>
    /// Displays a number in exponential notation, which replaces part of the number with E + n, where E (exponent) multiplies the preceding number by 10 to n.
    /// You can specify the number of decimal places you want to use.
    /// </summary>
    public partial class ScientificDataType : ICloneable
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ScientificError _error;
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
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ErrorSpecified => !Error.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (ScientificError) Error: Error: Gets or sets a reference that contains scientific data type error settings
        /// <summary>
        /// Gets or sets a reference that contains scientific data type error settings.
        /// </summary>
        /// <value>
        /// Scientific data type error settings
        /// </value>
        [XmlElement]
        [JsonProperty("error")]
        public ScientificError Error
        {
            get => _error ?? (_error = new ScientificError());
            set => _error = value;
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
        public override bool IsDefault => base.IsDefault && Error.IsDefault;
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(ScientificDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(ScientificDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            Error.Combine(reference.Error);

            base.Combine(reference);
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (ScientificDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public new ScientificDataType Clone()
        {
            var scientificyDataTypeCloned = (ScientificDataType)MemberwiseClone();
            scientificyDataTypeCloned.Error = Error.Clone();
            scientificyDataTypeCloned.Properties = Properties.Clone();

            return scientificyDataTypeCloned;
        }
        #endregion

        #endregion
    }
}
