
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="BaseError"/> model.
/// </summary>
[Serializable]
public partial class BaseErrorOptions : BaseOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="FontOptions"/> class.
    /// </summary>
    protected BaseErrorOptions()
    {
        Comment = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="BaseError"/>.
    /// </summary>
    /// <value>
    /// A <see cref="FontOptions"/> reference containing the set of available settings.
    /// </value>
    public static BaseErrorOptions Default => new();

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => Comment == null;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether bold style is applied in an existing <see cref="BaseError"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if bold style is applied to a <see cref="FontModel"/> instance or <b>YesNo.No</b> if bold style is not applied to a <see cref="FontModel"/> instance. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("comment")]
    public Comment Comment { get; set; }

    #endregion
}
