
namespace iTin.Core.Models.Design.Options
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Enums;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="ContentAlignmentModel"/> instance.
    /// </summary>
    [Serializable]
    public class ContentAlignmentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] ContentAlignmentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAlignmentOptions"/> class.
        /// </summary>
        public ContentAlignmentOptions()
        {
            Horizontal = null;
            Vertical = null;
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

        #region public static properties

        #region [public] {static} (ContentAlignmentOptions) Default: Gets a reference that contains the set of available settings to model an existing BorderModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="ContentAlignmentModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static ContentAlignmentOptions Default => new ContentAlignmentOptions();
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
        public override bool IsDefault => Horizontal == null && Vertical == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHorizontalAlignment?) Horizontal: Gets or sets the preferred horizontal alignment in an existing ContentAlignmentModel instance
        /// <summary>
        /// Gets or sets the preferred horizontal alignment in an existing <see cref="ContentAlignmentModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownHorizontalAlignment"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownHorizontalAlignment? Horizontal { get; set; }
        #endregion

        #region [public] (KnownVerticalAlignment?) Vertical: Gets or sets the preferred vertical alignment in an existing ContentAlignmentModel instance
        /// <summary>
        /// Gets or sets the preferred vertical alignment in an existing <see cref="ContentAlignmentModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownVerticalAlignment"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownVerticalAlignment? Vertical { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (ContentAlignmentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public ContentAlignmentOptions Clone() => (ContentAlignmentOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
