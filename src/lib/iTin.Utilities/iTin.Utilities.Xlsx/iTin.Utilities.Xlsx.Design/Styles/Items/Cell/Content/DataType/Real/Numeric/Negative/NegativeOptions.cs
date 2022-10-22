
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Styles;

namespace iTin.Core.Models.Design.Options
{
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="NegativeModel"/> model.
    /// </summary>
    [Serializable]
    public class NegativeOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] NegativeOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeOptions"/> class.
        /// </summary>
        public NegativeOptions()
        {
            Color = null;
            Sign = null;
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

        #region public static properties

        #region [public] {static} (NegativeOptions) Default: Returns a new instance containing the set of available settings to model an existing NegativeModel
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="NegativeModel"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="NegativeOptions"/> reference containing set of default options.
        /// </value>
        public static NegativeOptions Default => new NegativeOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownBasicColor?) Color: Gets or sets the preferred color for display a negative number for an existing NegativeModel instance
        /// <summary>
        /// Gets or sets the preferred color for display a negative number in an existing <see cref="NegativeModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred negative color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public KnownBasicColor? Color { get; set; }
        #endregion

        #region [public] (KnownNegativeSign?) Sign: Gets or sets the preferred visual negative sign in an existing NegativeModel instance is scalable
        /// <summary>
        /// Gets or sets the preferred visual negative sign in an existing <see cref="NegativeModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Visual format of negative value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("sign")]
        public KnownNegativeSign? Sign { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Sign == null && Color == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (NegativeOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public NegativeOptions Clone() => (NegativeOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
