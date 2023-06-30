
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    /// <summary>
    /// Defines <b>xlsx</b> sheet margins.
    /// </summary>
    public partial class XlsxDocumentMargins : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultTop = 20f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultLeft = 20f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultRight = 20f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultBottom = 20f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownUnit DefaultUnits = KnownUnit.Millimeters;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _top;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _right;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _bottom;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _left;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownUnit _unit;
        #endregion

        #region constructor/s

        #region [public] XlsxDocumentMargins(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxDocumentMargins"/> class.
        /// </summary>
        public XlsxDocumentMargins()
        {
            Top = DefaultTop;
            Left = DefaultLeft;
            Right = DefaultRight;
            Bottom = DefaultBottom;
            Units = DefaultUnits;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Create a new object that is a copy of the current instance
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

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxDocumentMargins) Default: Returns a new instance containing document margins settings
        /// <summary>
        /// Returns a new instance containing document margins settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxDocumentMargins"/> reference containing the default document margins settings.
        /// </value>
        public static XlsxDocumentMargins Default => new XlsxDocumentMargins();
        #endregion

        #endregion

        #region public properties

        #region [public] (float) Bottom: Gets or sets the preferred bottom margin of document
        /// <summary>
        /// Gets or sets the preferred bottom margin of document. The default is <b>20.0</b>.
        /// </summary>
        /// <value>
        /// Preferred bottom margin of document.
        /// </value>
        /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
        [XmlAttribute]
        [DefaultValue(DefaultBottom)]
        [JsonProperty("bottom")]
        public float Bottom
        {
            get => _bottom;
            set
            {
                SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

                _bottom = value;
            }
        }
        #endregion

        #region [public] (float) Left: Gets or sets the preferred left margin of document
        /// <summary>
        /// Gets or sets the preferred left margin of document. The default is <b>20.0</b>.
        /// </summary>
        /// <value>
        /// Preferred left margin of document. 
        /// </value>
        /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
        [XmlAttribute]
        [JsonProperty("left")]
        [DefaultValue(DefaultLeft)]
        public float Left
        {
            get => _left;
            set
            {
                SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

                _left = value;
            }
        }
        #endregion

        #region [public] (float) Right: Gets or sets the preferred right margin of document
        /// <summary>
        /// Gets or sets the preferred right margin of document. The default is <b>20.0</b>.
        /// </summary>
        /// <value>
        /// Preferred right margin of document. 
        /// </value>
        /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
        [XmlAttribute]
        [JsonProperty("right")]
        [DefaultValue(DefaultRight)]
        public float Right
        {
            get => _right;
            set
            {
                SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

                _right = value;
            }
        }
        #endregion

        #region [public] (float) Top: Gets or sets the preferred top margin of document
        /// <summary>
        /// Gets or sets the preferred top margin of document. The default is <b>20.0</b>.
        /// </summary>
        /// <value>
        /// Preferred top margin of document.
        /// </value>
        /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
        [XmlAttribute]
        [JsonProperty("top")]
        [DefaultValue(DefaultTop)]
        public float Top
        {
            get => _top;
            set
            {
                SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

                _top = value;
            }
        }
        #endregion

        #region [public] (KnownUnit) Units: Gets or sets the preferred units of margins
        /// <summary>
        /// Gets or sets the preferred units of margins. The default is <see cref="KnownUnit.Millimeters"/>.
        /// </summary>
        /// <value>
        /// Preferred units of margins. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [DefaultValue(DefaultUnits)]
        public KnownUnit Units
        {
            get => _unit;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _unit = value;
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
        public override bool IsDefault =>
            base.IsDefault &&
            Top.Equals(DefaultTop) &&
            Right.Equals(DefaultRight) &&
            Left.Equals(DefaultLeft) &&
            Bottom.Equals(DefaultBottom) &&
            Units.Equals(DefaultUnits);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxDocumentMargins) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxDocumentMargins Clone()
        {
            var cloned = (XlsxDocumentMargins) MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }

        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxDocumentMargins): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxDocumentMargins reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Bottom.Equals(DefaultBottom))
            {
                Bottom = reference.Bottom;
            }

            if (Left.Equals(DefaultLeft))
            {
                Left = reference.Left;
            }

            if (Right.Equals(DefaultRight))
            {
                Right = reference.Right;
            }

            if (Top.Equals(DefaultTop))
            {
                Top = reference.Top;
            }

            if (Units.Equals(DefaultUnits))
            {
                Units = reference.Units;
            }
        }
        #endregion

        #endregion
    }
}
