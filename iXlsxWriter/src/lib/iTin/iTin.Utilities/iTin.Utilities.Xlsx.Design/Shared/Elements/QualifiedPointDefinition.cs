
namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> point.
/// </summary>
public partial class QualifiedPointDefinition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QualifiedPointDefinition"/> class.
    /// </summary>
    public QualifiedPointDefinition()
    {
        WorkSheet = string.Empty;
        Point = XlsxPoint.Default;
    }


    /// <summary>
    /// Gets or sets a value containing worksheet name.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing worksheet name.
    /// </value>
    public string WorkSheet { get; set; }

    /// <summary>
    /// Gets or sets a value containig the data point.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPoint"/> containing the data point.
    /// </value>
    public XlsxPoint Point { get; set; }
}
