
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Represents a <b>xlsx</b> soft edge shape effect.
    /// </summary>
    public partial class XlsxSoftEdgeShapeEffect : ICombinable<XlsxSoftEdgeShapeEffect>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultSize = 0.0f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _size;
        #endregion

        #region constructor/s

        #region [public] XlsxSoftEdgeShapeEffect(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxSoftEdgeShapeEffect"/> class.
        /// </summary>
        public XlsxSoftEdgeShapeEffect()
        {
            Size = DefaultSize;
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

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxSoftEdgeShapeEffect>.Combine(XlsxSoftEdgeShapeEffect): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxSoftEdgeShapeEffect>.Combine(XlsxSoftEdgeShapeEffect reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxSoftEdgeShapeEffect) None: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect None => new XlsxSoftEdgeShapeEffect();
        #endregion

        #region [public] {static} (XlsxSoftEdgeShapeEffect) SoftEdge1: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect SoftEdge1 => new XlsxSoftEdgeShapeEffect { Show = YesNo.Yes, Size = 1};
        #endregion

        #region [public] {static} (XlsxSoftEdgeShapeEffect) SoftEdge2: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect SoftEdge2 => new XlsxSoftEdgeShapeEffect { Show = YesNo.Yes, Size = 2.5f};
        #endregion

        #region [public] {static} (XlsxSoftEdgeShapeEffect) SoftEdge5: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect SoftEdge5 => new XlsxSoftEdgeShapeEffect { Show = YesNo.Yes, Size = 5.0f};
        #endregion

        #region [public] {static} (XlsxSoftEdgeShapeEffect) SoftEdge10: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect SoftEdge10 => new XlsxSoftEdgeShapeEffect { Show = YesNo.Yes, Size = 10.0f};
        #endregion

        #region [public] {static} (XlsxSoftEdgeShapeEffect) SoftEdge25: Returns a new instance containig the soft edge shape effect
        /// <summary>
        /// Returns a new instance containig the soft edge shape effect.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing the soft edge shape effect.
        /// </value>
        public static XlsxSoftEdgeShapeEffect SoftEdge25 => new XlsxSoftEdgeShapeEffect { Show = YesNo.Yes, Size = 25.0f};
        #endregion

        #endregion

        #region public properties

        #region [public] (float) Size: Gets or sets the preferred reflection effect size value
        /// <summary>
        /// Gets or sets the preferred reflection effect size value, expressed in points. The default is <b>0.0</b>.
        /// </summary>
        /// <value>
        /// Preferred reflection effect size value.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0.0 and 100.0.</exception>
        [XmlAttribute]
        [JsonProperty("size")]
        [DefaultValue(DefaultSize)]
        public float Size
        {
            get => _size;
            set
            {
                SentinelHelper.ArgumentOutOfRange(nameof(Size), value, 0.0f, 100.0f);

                _size = value;
            }
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays reflection effect
        /// <summary>
        /// Gets or sets a value that determines whether displays reflection effect. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if display reflection effect; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("show")]
        [DefaultValue(DefaultShow)]
        public YesNo Show
        {
            get => _show;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _show = value;
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
        public override bool IsDefault =>
            base.IsDefault &&
            Size.Equals(DefaultSize) &&
            Show.Equals(DefaultShow);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxSoftEdgeShapeEffect) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxSoftEdgeShapeEffect Clone()
        {
            var cloned = (XlsxSoftEdgeShapeEffect)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxSoftEdgeShapeEffectOptions): Apply specified options to this font
        /// <summary>
        /// Apply specified options to this shadow.
        /// </summary>
        public virtual void ApplyOptions(XlsxSoftEdgeShapeEffectOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Size
            float? sizeOption = options.Size;
            bool sizeHasValue = sizeOption.HasValue;
            if (sizeHasValue)
            {
                Size = sizeOption.Value;
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
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxSoftEdgeShapeEffect): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(XlsxSoftEdgeShapeEffect reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Size.Equals(DefaultSize))
            {
                Size = reference.Size;
            }
        }
        #endregion

        #endregion
    }
}
