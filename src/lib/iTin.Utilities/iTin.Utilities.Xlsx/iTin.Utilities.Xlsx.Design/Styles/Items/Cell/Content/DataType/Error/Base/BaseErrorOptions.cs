
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class BaseErrorOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] BaseErrorOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseErrorOptions"/> class.
        /// </summary>
        public BaseErrorOptions()
        {
            Comment = null;
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

        #region [public] {static} (BaseErrorOptions) Default: Returns a new instance containing the set of available settings to model an existing BaseError instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="BaseError"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="BaseErrorOptions"/> reference containing set of default options.
        /// </value>
        public static BaseErrorOptions Default => new BaseErrorOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) CommentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool CommentSpecified => Comment != null;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxCellCommentOptions) Comment: Gets or sets a value that defines font cell style in an existing XlsxCellComment instance.
        /// <summary>
        /// Gets or sets a value that defines cell style content in an existing <see cref="XlsxCellComment"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellCommentOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("comment")]
        public XlsxCellCommentOptions Comment { get; set; }
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
        public override bool IsDefault => base.IsDefault && Comment == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (BaseErrorOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public BaseErrorOptions Clone()
        {
            var cloned = (BaseErrorOptions)MemberwiseClone();
            if (Comment != null)
            {
                cloned.Comment = Comment.Clone();
            }

            return cloned;
        } 
        #endregion

        #endregion
    }
}
