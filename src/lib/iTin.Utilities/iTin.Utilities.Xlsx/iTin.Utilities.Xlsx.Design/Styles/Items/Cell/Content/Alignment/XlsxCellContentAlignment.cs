
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// A Specialization of <see cref="BaseContentAlignment"/> class.<br/>
    /// Defines a <b>xlsx</b> cell content alignment.
    /// </summary>
    public partial class XlsxCellContentAlignment
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownVerticalAlignment DefaultVerticalAlignment = KnownVerticalAlignment.Center;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownVerticalAlignment _vertical;
        #endregion

        #region constructor/s

        #region [public] XlsxCellContentAlignment(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellContentAlignment"/> class.
        /// </summary>
        public XlsxCellContentAlignment()
        {
            Vertical = DefaultVerticalAlignment;
        }
        #endregion

        #endregion

        #region public new static properties

        #region [public] {new} {static} (XlsxCellContentAlignment) Default: Returns a new instance containing default cell content alignment style settings
        /// <summary>
        /// Returns a new instance containing default cell content alignment style settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellContentAlignment"/> reference containing the default content alignment settings.
        /// </value>
        public new static XlsxCellContentAlignment Default => new XlsxCellContentAlignment();
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownVerticalAlignment) Vertical: Gets or sets the preferred cell content alignment
        /// <summary>
        /// Gets or sets the preferred cell content alignment. The default is <see cref="KnownVerticalAlignment.Center"/>.
        /// </summary>
        /// <value>
        /// Preferred cell content alignment.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultVerticalAlignment)]
        public KnownVerticalAlignment Vertical
        {
            get => _vertical;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _vertical = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Vertical.Equals(DefaultVerticalAlignment);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxCellContentAlignment) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxCellContentAlignment Clone() => (XlsxCellContentAlignment)MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellContentAlignmentOptions): Apply specified options to this content
        /// <summary>
        /// Apply specified options to this content.
        /// </summary>
        public virtual void ApplyOptions(XlsxCellContentAlignmentOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Horizontal
            KnownHorizontalAlignment? horizontalOption = options.Horizontal;
            bool horizontalHasValue = horizontalOption.HasValue;
            if (horizontalHasValue)
            {
                Horizontal = horizontalOption.Value;
            }
            #endregion

            #region Vertical
            KnownVerticalAlignment? verticalOption = options.Vertical;
            bool verticalHasValue = verticalOption.HasValue;
            if (verticalHasValue)
            {
                Vertical = verticalOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxCellContentAlignment): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxCellContentAlignment reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            if (Vertical.Equals(DefaultVerticalAlignment))
            {
                Vertical = reference.Vertical;
            }
        }
        #endregion

        #endregion
    }
}
