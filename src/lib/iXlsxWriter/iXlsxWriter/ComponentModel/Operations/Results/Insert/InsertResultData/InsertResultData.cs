
using System.IO;

namespace iXlsxWriter.ComponentModel.Result.Insert;

/// <summary>
/// Represents insert data for an object <see cref="InsertResult"/>.
/// </summary>
public class InsertResultData
{
    #region internal properties

    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    internal IInput Context { get; set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    public Stream InputStream { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    public Stream OutputStream { get; set; }
        
    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() => $"{(OutputStream.Length > InputStream.Length ? "Modified" : "Default")}";

    #endregion
}
