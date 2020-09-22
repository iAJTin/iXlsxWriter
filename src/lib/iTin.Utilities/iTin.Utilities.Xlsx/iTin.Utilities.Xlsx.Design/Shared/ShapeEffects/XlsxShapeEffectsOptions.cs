
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxShapeEffects"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxShapeEffectsOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxShapeEffectsOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxShapeEffectsOptions"/> class.
        /// </summary>
        public XlsxShapeEffectsOptions()
        {
            Illumination = null;
            Reflection = null;
            Shadow = null;
            SoftEdge = null;
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

        #region [public] {static} (XlsxShapeEffectsOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxShapeEffects instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxShapeEffects"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static XlsxShapeEffectsOptions Default => new XlsxShapeEffectsOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) IlluminationSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IlluminationSpecified => Illumination != null;
        #endregion

        #region [public] (bool) ReflectionSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ReflectionSpecified => Reflection != null;
        #endregion

        #region [public] (bool) ShadowSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ShadowSpecified => Shadow != null;
        #endregion

        #region [public] (bool) SoftEdgeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool SoftEdgeSpecified => SoftEdge != null;
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
        public override bool IsDefault =>
            base.IsDefault &&
            Illumination == null &&
            Reflection == null &&
            Shadow == null &&
            SoftEdge == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxIlluminationShapeEffectOptions) Illumination: Gets or sets a value containing shape illumination effect settings in an existing XlsxIlluminationShapeEffect instance
        /// <summary>
        /// Gets or sets a value containing shape illumination effect settings in an existing <see cref="XlsxShapeEffects"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxIlluminationShapeEffectOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("illumination")]
        public XlsxIlluminationShapeEffectOptions Illumination { get; set; }
        #endregion

        #region [public] (XlsxReflectionShapeEffectOptions) Reflection:  Gets or sets a value that containing shape reflection effect settings in an existing in an existing XlsxShapeEffects instance
        /// <summary>
        /// Gets or sets a value that containing shape reflection effect settings in an existing <see cref="XlsxShapeEffects"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxReflectionShapeEffectOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("reflection")]
        public XlsxReflectionShapeEffectOptions Reflection { get; set; }
        #endregion

        #region [public] (XlsxBaseShadowOptions) Shadow:  Gets or sets a value that containing shape shadow effect settings in an existing in an existing XlsxShapeEffects instance
        /// <summary>
        /// Gets or sets a value that containing shape shadow effect settings in an existing <see cref="XlsxShapeEffects"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxBaseShadowOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("shadow")]
        public XlsxBaseShadowOptions Shadow { get; set; }
        #endregion

        #region [public] (XlsxSoftEdgeShapeEffectOptions) SoftEdge: Gets or sets a value that containing shape softedge effect settings in an existing in an existing XlsxShapeEffects instance
        /// <summary>
        /// Gets or sets a value that containing shape softedge effect settings in an existing <see cref="XlsxShapeEffects"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxSoftEdgeShapeEffectOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("soft-edge")]
        public XlsxSoftEdgeShapeEffectOptions SoftEdge { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxShapeEffectsOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxShapeEffectsOptions Clone()
        {
            var cloned = (XlsxShapeEffectsOptions) MemberwiseClone();
            cloned.Illumination = Illumination.Clone();
            cloned.Reflection = Reflection.Clone();
            cloned.Shadow = Shadow.Clone();
            cloned.SoftEdge = SoftEdge.Clone();

            return cloned;
        }

        #endregion

        #endregion
    }
}
