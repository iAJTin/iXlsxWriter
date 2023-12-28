
namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a cell styles to use with data.
/// </summary>
public partial class DictionaryStyles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryStyles"/> class.
    /// </summary>
    public DictionaryStyles()
    {
        Headers = new DataStyles();
        Values = new DataStyles();
    }


    /// <summary>
    /// Gets or sets the preferred cell headers styles.
    /// </summary>
    /// <value>
    /// Preferred cell headers styles.
    /// </value>
    public DataStyles Headers { get; set; }

    /// <summary>
    /// Gets or sets the preferred cell values styles.
    /// </summary>
    /// <value>
    /// Preferred cell values styles.
    /// </value>
    public DataStyles Values { get; set; }
}
