
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellMerge"/> instance.
/// </summary>
/// </summary>
[Serializable]
public partial class XlsxCellMergeOptions 
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellMergeOptions"/> class.
    /// </summary>
    public XlsxCellMergeOptions()
    {
        Cells = null;
        Orientation = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellMerge"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellMergeOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxCellMergeOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the merge cells in an existing <see cref="XlsxCellMerge"/>" instance.
    /// </summary>
    /// <value>
    /// Merge cells.
    /// </value>
    [XmlAttribute]
    [JsonProperty("cells")]
    public int? Cells { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates preferred merge orientation for an existing <see cref="XlsxCellMerge"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
    /// </value>
    [XmlAttribute]
    [JsonProperty("orientation")]
    public KnownMergeOrientation? Orientation { get; set; }

    #endregion
}
