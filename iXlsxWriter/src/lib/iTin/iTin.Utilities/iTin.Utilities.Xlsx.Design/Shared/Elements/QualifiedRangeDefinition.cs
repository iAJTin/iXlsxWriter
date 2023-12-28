
namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> range.
/// </summary>
public partial class QualifiedRangeDefinition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QualifiedRangeDefinition"/> class.
    /// </summary>
    public QualifiedRangeDefinition()
    {
        WorkSheet = string.Empty;
        Range = XlsxRange.Default;
    }


    /// <summary>
    /// Gets or sets a value containing worksheet name.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing worksheet name.
    /// </value>
    public string WorkSheet { get; set; }

    /// <summary>
    /// Gets or sets a value containig the data range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> containing the data range.
    /// </value>
    public XlsxRange Range { get; set; }
}
