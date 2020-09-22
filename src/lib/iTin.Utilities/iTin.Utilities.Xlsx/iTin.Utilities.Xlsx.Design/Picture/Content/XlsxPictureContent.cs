
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// A Specialization of <see cref="BaseContent"/> class.<br/>
    /// Defines a <b>xlsx</b> picture content.
    /// </summary>
    public partial class XlsxPictureContent : ICombinable<XlsxPictureContent>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultTransparency = 0;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _transparency;
        #endregion

        #region constructor/s

        #region [public] XlsxPictureContent(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxPictureContent"/> class.
        /// </summary>
        public XlsxPictureContent()
        {
            Transparency = DefaultTransparency;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxPictureContent>.Combine(XlsxPictureContent): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference to combine with this instance</param>
        void ICombinable<XlsxPictureContent>.Combine(XlsxPictureContent reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public new readonly static properties

        #region [public] {new} {static} (XlsxPictureContent) Default: Returns a new instance containing default picture content style settings
        /// <summary>
        /// Returns a new instance containing default picture content style settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPictureContent"/> reference containing the default picture content style settings.
        /// </value>
        public new static XlsxPictureContent Default => new XlsxPictureContent();
        #endregion

        #endregion

        #region public properties

        #region [public] (int) Transparency: Gets or sets the preferred picture content transparency percentage value
        /// <summary>
        /// Gets or sets the preferred picture content transparency percentage value. The default value is <b>0</b>.
        /// </summary>
        /// <value>
        /// Preferred picture content transparency percentage value.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
        [XmlAttribute]
        [JsonProperty("transparency")]
        [DefaultValue(DefaultTransparency)]
        public int Transparency
        {
            get => _transparency;
            set
            {
                SentinelHelper.ArgumentOutOfRange(nameof(Transparency), value, 0, 100);
                _transparency = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool IsDefault => base.IsDefault && Transparency.Equals(DefaultTransparency);
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxPictureContentOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxPictureContentOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Color
            string colorOption = options.Color;
            bool colorHasValue = !colorOption.IsNullValue();
            if (colorHasValue)
            {
                Color = colorOption;
            }
            #endregion

            #region Show
            YesNo? showOption = options.Show;
            bool showHasValue = showOption.HasValue;
            if (showHasValue)
            {
                Show = showOption.Value;
            }
            #endregion

            #region Transparency
            int? transparencyOption = options.Transparency;
            bool transparencyHasValue = transparencyOption.HasValue;
            if (transparencyHasValue)
            {
                Transparency = transparencyOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxPictureContent): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxPictureContent reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            if (Transparency.Equals(DefaultTransparency))
            {
                Transparency = reference.Transparency;
            }
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxCellContent) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxPictureContent Clone()
        {
            var cloned = (XlsxPictureContent) base.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
