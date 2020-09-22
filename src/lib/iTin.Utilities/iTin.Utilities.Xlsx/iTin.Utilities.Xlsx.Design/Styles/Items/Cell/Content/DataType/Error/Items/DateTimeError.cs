
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// A Specialization of <see cref="BaseError"/> class.<br/>
    /// Represents the error structure for datetime data type. Allows us to set a default value and an additional comment.
    /// </summary>
    public partial class DateTimeError : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultValue = "MinValue";
        #endregion

        #region private field members

        #endregion

        #region constructor/s

        #region [public] DateTimeError(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeError"/> class.
        /// </summary>
        public DateTimeError()
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

        #region [public] (DateTime) DateTimeValue: Gets a value that represent the date time value
        /// <summary>
        /// Gets a value that represent the date time value.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> that represent the date time value.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public DateTime DateTimeValue
        {
            get
            {
                DateTime value;
                switch (Value)
                {
                    case "MinValue":
                        value = new DateTime(1900, 1, 1);
                        break;

                    case "MaxValue":
                        value = DateTime.MaxValue;
                        break;

                    case "Today":
                        value = DateTime.Today;
                        break;

                    default:
                        var isValid = DateTime.TryParse(Value, out value);
                        if (!isValid)
                        {
                            value = new DateTime(1900, 1, 1);
                        }                            
                        break;
                }

                return value;
            }
        }
        #endregion

        #region [public] (string) Value: Gets or sets preferred default value when occurs an error
        /// <summary>
        /// Gets or sets preferred default value when occurs an error. The default is <b>MinValue</b>.
        /// </summary>
        /// <value>
        /// Preferred default value when occurs an error. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("value")]
        [DefaultValue(DefaultValue)]
        public string Value { get; set; }
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

        #region [public] {new} (DateTimeError) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public new DateTimeError Clone()
        {
            var datetimeErrorCloned = (DateTimeError)MemberwiseClone();
            datetimeErrorCloned.Comment = Comment.Clone();
            datetimeErrorCloned.Properties = Properties.Clone();

            return datetimeErrorCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(DateTimeError): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(DateTimeError reference)
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
