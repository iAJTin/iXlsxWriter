
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> shape effects.
/// </summary>
public partial class XlsxShapeEffects
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseShadow _shadow;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxSoftEdgeShapeEffect _softEdge;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxReflectionShapeEffect _reflection;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxIlluminationShapeEffect _illumination;

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig default shape effects.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShapeEffects"/> reference containing default shape effects.
    /// </value>
    public static XlsxShapeEffects Default => new();

    #endregion

    #region public readonly properties

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
    public bool IlluminationSpecified => !Illumination.IsDefault;

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
    public bool ReflectionSpecified => !Reflection.IsDefault;

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
    public bool ShadowSpecified => !Shadow.IsDefault;

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
    public bool SoftEdgeSpecified => !SoftEdge.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value containing picture illumination shape effect settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing picture illumination shape effect settings.
    /// </value>
    [XmlElement]
    [JsonProperty("illumination")]
    public XlsxIlluminationShapeEffect Illumination
    {
        get => _illumination ??= XlsxIlluminationShapeEffect.None;
        set => _illumination = value;
    }

    /// <summary>
    /// Gets or sets a value containing picture reflection shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxReflectionShapeEffect"/> reference containing picture reflection shape effect.
    /// </value>
    [XmlElement]
    [JsonProperty("reflection")]
    public XlsxReflectionShapeEffect Reflection
    {
        get => _reflection ??= XlsxReflectionShapeEffect.None;
        set => _reflection = value;
    }

    /// <summary>
    /// Gets or sets a value containing picture shadow shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseShadow"/> reference containing picture shadow shape effect.
    /// </value>
    [XmlElement]
    [JsonProperty("shadow")]
    public XlsxBaseShadow Shadow
    {
        get => _shadow ??= XlsxOuterShadow.None;
        set => _shadow = value;
    }

    /// <summary>
    /// Gets or sets a value containing picture soft edge shape effect.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSoftEdgeShapeEffect"/> reference containing picture soft edge shape effect.
    /// </value>
    [XmlElement]
    [JsonProperty("soft-edge")]
    public XlsxSoftEdgeShapeEffect SoftEdge
    {
        get => _softEdge ??= XlsxSoftEdgeShapeEffect.None;
        set => _softEdge = value;
    }

    #endregion
}
