
using iXlsxWriter.ComponentModel.DataProvider;

namespace iXlsxWriter.ComponentModel.DataInput;

/// <summary>
/// Declares a generic data input.
/// </summary>
public interface IDataInput
{        
    /// <summary>
    /// Gets a value indicating whether you can create an <strong>XML</strong> file from the current instance of the object.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if you can create an <strong>XML</strong>; otherwise, <strong>false</strong>.
    /// </value>
    object Data { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// </returns>
    IDataProvider GetDataProvider();
}
