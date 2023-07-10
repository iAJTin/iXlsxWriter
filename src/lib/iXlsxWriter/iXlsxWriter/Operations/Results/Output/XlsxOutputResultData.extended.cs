
namespace iXlsxWriter.ComponentModel.Result.Output;

public partial class XlsxOutputResultData
{
    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() =>
        $"IsZipped={IsZipped}, OutputType={OutputType}";
}
