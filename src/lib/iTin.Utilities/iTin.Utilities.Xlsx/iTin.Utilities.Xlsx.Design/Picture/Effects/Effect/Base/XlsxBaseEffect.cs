
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing.Imaging;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Base class for different effects compatible with a <see cref="XlsxPicture"/> object.<br/>
    /// Which acts as the base class for different image effects.
    /// </summary>
    /// <remarks>
    ///   <para>The following table shows the different effects.</para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="XlsxDisabledEffect"/></term>
    ///       <description>Represents disabled effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxGrayScaleEffect"/></term>
    ///       <description>Represents gray-scale effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxGrayScaleRedEffect"/></term>
    ///       <description>Represents gray-scale red effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxGrayScaleGreenEffect"/></term>
    ///       <description>Represents gray-scale green effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxGrayScaleBlueEffect"/></term>
    ///       <description>Represents gray-scale blue effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxBrightnessEffect"/></term>
    ///       <description>Represents brightness effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxMoreBrightnessEffect"/></term>
    ///       <description>Represents more brightness effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxDarkEffect"/></term>
    ///       <description>Represents brightness effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxMoreDarkEffect"/></term>
    ///       <description>Represents more brightness effect.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxOpacityEffect"/></term>
    ///       <description>Represents opacity effect.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public abstract partial class XlsxBaseEffect : ICloneable
    {
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

        #region [public] (XlsxEffectsCollection) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="XlsxBaseEffect"/>.
        /// </summary>
        /// <value>
        /// The <see cref="XlsxEffectsCollection"/> that owns this <see cref="XlsxBaseEffect"/>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XlsxEffectsCollection Owner { get; private set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBaseEffect) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBaseEffect Clone()
        {
            var cloned = (XlsxBaseEffect)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public abstract methods

        #region [public] {abstract} (ImageAttributes) Apply(): Returns the manipulation of the colors in an image to an effect
        /// <summary>
        /// Returns the manipulation of the colors in an image to an effect.
        /// </summary>
        /// <returns>
        /// A <see cref="ImageAttributes"/> object that contains the information about how bitmap colors are manipulated. 
        /// </returns>
        public abstract ImageAttributes Apply();
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxEffectsCollection): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxBaseEffect"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxEffectsCollection reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
