
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="NumericDataType"/> class.<br/>
    /// You can specify the number of decimal places that you want to use, whether you want to use a thousands separator, and how you want to display negative numbers. 
    /// </summary>
    public partial class NumberDataType : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultSeparator = YesNo.No;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _separator;
        #endregion

        #region constructor/s

        #region [public] NumberDataType(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberDataType"/> class.
        /// </summary>
        public NumberDataType()
        {
            Separator = DefaultSeparator;
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

        #region [public] (YesNo) Separator: Gets or sets a value indicating whether displays thousands separator
        /// <summary>
        /// Gets or sets a value indicating whether displays thousands separator. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes" /> if displays thousands separator; otherwise, <see cref="YesNo.No"/>. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("separator")]
        [DefaultValue(DefaultSeparator)]
        public YesNo Separator
        {
            get => _separator;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _separator = value;
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
        public override bool IsDefault => base.IsDefault && Separator.Equals(DefaultSeparator);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (NumberDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new NumberDataType Clone()
        {
            var numberDataTypeCloned = (NumberDataType)MemberwiseClone();
            numberDataTypeCloned.Properties = Properties.Clone();

            return numberDataTypeCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(NumberDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual  void Combine(NumberDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Separator.Equals(DefaultSeparator))
            {
                Separator = reference.Separator;
            }

            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
