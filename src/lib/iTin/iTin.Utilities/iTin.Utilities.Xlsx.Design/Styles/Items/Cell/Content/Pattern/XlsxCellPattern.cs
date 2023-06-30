
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core;
using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="IPattern"/> interface.<br/>
    /// Defines a generic pattern.
    /// </summary>
    public partial class XlsxCellPattern : IPattern
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultColor = "Transparent";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownPatternType DefaultPatternType = KnownPatternType.Solid;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _color;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownPatternType _type;
        #endregion

        #region constructor/s

        #region [public] XlsxCellPattern(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellPattern"/> class.
        /// </summary>
        public XlsxCellPattern()
        {
            Color = DefaultColor;
            PatternType = DefaultPatternType;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region [private] (object) ICloneable.Clone(): Create a new object that is a copy of the current instance
        /// <inheritdoc/>
        /// <summary>
        /// Create a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="object"/> that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #region ICombinable

        #region explicit

        #region (object) ICombinable<IPattern>.Combine(IPattern): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<IPattern>.Combine(IPattern reference) => Combine((XlsxCellPattern)reference);
        #endregion

        #endregion

        #endregion

        #region IPattern

        #region explicit

        #region (bool) IPattern.IsEmpty: Gets a value indicating whether this style is an empty style
        /// <summary>
        /// Gets a value indicating whether this style is an empty style.
        /// </summary>
        /// <value>
        /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
        bool IPattern.IsEmpty => IsDefault;
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) IsEmpty: Gets a value indicating whether this style is an empty style
        /// <summary>
        /// Gets a value indicating whether this style is an empty style.
        /// </summary>
        /// <value>
        /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
        /// </value>        
        public bool IsEmpty => IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets preferred pattern color
        /// <summary>
        /// Gets or sets preferred pattern color. The default is <b>Black</b>.
        /// </summary>
        /// <value>
        /// Preferred pattern color.
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        [XmlAttribute]
        [JsonProperty("color")]
        [DefaultValue(DefaultColor)]
        public string Color
        {
            get => _color;
            set
            {
                SentinelHelper.ArgumentNull(value, nameof(Color));

                _color = value;
            }
        }
        #endregion

        #region [public] (KnownPatternType) PatternType: Gets or sets preferred of pattern type
        /// <summary>
        /// Gets or sets preferred pattern type. The default is <see cref="KnownPatternType.Solid"/>.
        /// </summary>
        /// <value>
        /// Preferred pattern type. 
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        [XmlAttribute]
        [JsonProperty("patterntype")]
        [DefaultValue(DefaultPatternType)]
        public KnownPatternType PatternType
        {
            get => _type;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _type = value;
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (Color) GetColor(): Gets a reference to the Color structure that represents color for this border
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
        /// </returns> 
        public Color GetColor() => ColorHelper.GetColorFromString(Color);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => Color.Equals(DefaultColor) && PatternType.Equals(DefaultPatternType);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellPattern) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellPattern Clone()
        {
            var patternCloned = (XlsxCellPattern)MemberwiseClone();
            patternCloned.Properties = Properties.Clone();

            return patternCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellPatternOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxCellPatternOptions options)
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

            #region PatternType
            KnownPatternType? patternTypeOption = options.PatternType;
            bool patternTypeHasValue = patternTypeOption.HasValue;
            if (patternTypeHasValue)
            {
                PatternType = patternTypeOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxCellPattern): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(XlsxCellPattern reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Color.Equals(DefaultColor))
            {
                Color = reference.Color;
            }

            if (PatternType.Equals(DefaultPatternType))
            {
                PatternType = reference.PatternType;
            }
        }
        #endregion

        #endregion
    }
}
