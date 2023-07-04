
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="NumericError"/> instance.
/// </summary>
[Serializable]
public partial class NumericErrorOptions : BaseErrorOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericErrorOptions"/> class.
    /// </summary>
    public NumericErrorOptions()
    {
        Value = null;
    }

    #endregion

    #region public new static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="NumericError"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static NumericErrorOptions Default => new();

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => Value == null;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred color in an existing <see cref="NumericError"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred shadow color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("value")]
    public float? Value { get; set; }

    #endregion
}
