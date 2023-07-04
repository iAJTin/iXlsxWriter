
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxShapeEffects"/> instance.
/// </summary>
[Serializable]
public class XlsxShapeEffectsOptions : BaseOptions, ICloneable
{
    #region constructor/s

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

    #region interfaces

    #region ICloneable

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

    #region public static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxShapeEffects"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public static XlsxShapeEffectsOptions Default => new();

    #endregion

    #region public readonly properties

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

    #region public override readonly properties

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

    #region public properties

    /// <summary>
    /// Gets or sets a value containing shape illumination effect settings in an existing <see cref="XlsxShapeEffects"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxIlluminationShapeEffectOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("illumination")]
    public XlsxIlluminationShapeEffectOptions Illumination { get; set; }

    /// <summary>
    /// Gets or sets a value that containing shape reflection effect settings in an existing <see cref="XlsxShapeEffects"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxReflectionShapeEffectOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("reflection")]
    public XlsxReflectionShapeEffectOptions Reflection { get; set; }

    /// <summary>
    /// Gets or sets a value that containing shape shadow effect settings in an existing <see cref="XlsxShapeEffects"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxBaseShadowOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("shadow")]
    public XlsxBaseShadowOptions Shadow { get; set; }

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

    #region public methods

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
}
