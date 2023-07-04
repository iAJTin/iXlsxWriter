
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a cell styles to use with data.
/// </summary>
public class DictionaryStyles : ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryStyles"/> class.
    /// </summary>
    public DictionaryStyles()
    {
        Headers = new DataStyles();
        Values = new DataStyles();
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public properties

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

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public DictionaryStyles Clone()
    {
        var cloned = (DictionaryStyles)MemberwiseClone();
        cloned.Headers = Headers.Clone();
        cloned.Values = Values.Clone();

        return cloned;
    }

    #endregion
}
