
using System.Data;

using iXlsxWriter.ComponentModel.DataProvider;

namespace iXlsxWriter.ComponentModel.DataInput;

/// <summary>
/// Class than allows you to export an object of type <see cref="DataSet" />.
/// </summary>
[InputOptions(AdapterType = typeof(DataSetProvider))]
public class DataSetInput : BaseDataInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetInput" /> class.
    /// </summary>
    /// <param name="dataSet">A <see cref="DataSet" /> object than contains the information.</param>
    public DataSetInput(DataSet dataSet) 
        : base(dataSet)
    {
    }
}
