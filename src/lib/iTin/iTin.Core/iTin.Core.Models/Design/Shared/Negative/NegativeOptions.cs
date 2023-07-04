
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="Negative"/> instance.
/// </summary>
[Serializable]
public partial class NegativeOptions : BaseOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="NegativeOptions"/> class.
    /// </summary>
    public NegativeOptions()
    {
        Sign = null;
        Color = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="Negative"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public static NegativeOptions Default => new();

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        Color == null &&
        Sign == null;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred color in an existing <see cref="Negative"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred negative color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public KnownBasicColor? Color { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether an existing. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("sign")]
    public KnownNegativeSign? Sign { get; set; }

    #endregion
}
