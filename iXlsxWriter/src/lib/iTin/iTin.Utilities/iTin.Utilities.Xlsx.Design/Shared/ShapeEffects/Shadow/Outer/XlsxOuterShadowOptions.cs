
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadowOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxOuterShadow"/> instance.
/// </summary>
[Serializable]
public partial class XlsxOuterShadowOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxOuterShadowOptions"/> class.
    /// </summary>
    public XlsxOuterShadowOptions()
    {
        Size = null;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the preferred shadow size, expressed in % in an existing <see cref="XlsxOuterShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred shadow size value, expressed in %.
    /// </value>
    [XmlAttribute]
    [JsonProperty("size")]
    public int? Size { get; set; }

    #endregion
}
