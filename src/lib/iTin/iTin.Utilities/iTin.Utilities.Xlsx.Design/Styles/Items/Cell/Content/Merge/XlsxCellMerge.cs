
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Represents a merge cells definition. Includes cells number in merge and orientation.
/// </summary>
public partial class XlsxCellMerge
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultMergeCells = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownMergeOrientation DefaultMergeOrientation = KnownMergeOrientation.Horizontal;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownMergeOrientation _mergeOrientation;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellMerge"/> class.
    /// </summary>
    public XlsxCellMerge()
    {
        Cells = DefaultMergeCells;
        Orientation = DefaultMergeOrientation;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the merge cells. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Merge cells.
    /// </value>
    [XmlAttribute]
    [JsonProperty("cells")]
    [DefaultValue(DefaultMergeCells)]
    public int Cells { get; set; }

    /// <summary>
    /// Gets or sets preferred merge orientation. The default value is <see cref="KnownMergeOrientation.Horizontal"/>.
    /// </summary>
    /// <value>
    /// Preferred merge orientation.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("orientation")]
    [DefaultValue(DefaultMergeOrientation)]
    public KnownMergeOrientation Orientation
    {
        get => _mergeOrientation;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _mergeOrientation = value;
        }
    }

    #endregion
}
