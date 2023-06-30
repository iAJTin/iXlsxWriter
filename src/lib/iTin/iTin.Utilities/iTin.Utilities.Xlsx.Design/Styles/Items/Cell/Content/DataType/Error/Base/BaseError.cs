
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Base class for different data types errors.
    /// Which acts as the base class for the different data types errors.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The following table shows the different data types errors.
    ///   </para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="NumericError"/></term>
    ///       <description>Reference for numeric data type error settings.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="DateTimeError"/></term>
    ///       <description>Reference for datetime data type error settings.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class BaseError : ICloneable
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellComment _comment;
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

        #region [public] (bool) CommentSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool CommentSpecified => Comment != null;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxCellComment) Comment: Gets or sets a reference that contains the error comment
        /// <summary>
        /// Gets or sets a reference that contains the error comment.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellComment"/> reference containing the error cell comment.
        /// </value>
        [XmlElement]
        [JsonProperty("comment")]
        public XlsxCellComment Comment
        {
            get => _comment ?? (_comment = new XlsxCellComment());
            set => _comment = value;
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
        public override bool IsDefault => Comment.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (BaseError) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public BaseError Clone()
        {
            var baseErrorCloned = (BaseError)MemberwiseClone();
            baseErrorCloned.Comment = Comment.Clone();
            baseErrorCloned.Properties = Properties.Clone();

            return baseErrorCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(BaseErrorOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(BaseErrorOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Comment
            Comment.ApplyOptions(options.Comment);
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(BaseError): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(BaseError reference)
        {
            if (reference == null)
            {
                return;
            }

            Comment.Combine(reference.Comment);
        }
        #endregion

        #endregion
    }
}
