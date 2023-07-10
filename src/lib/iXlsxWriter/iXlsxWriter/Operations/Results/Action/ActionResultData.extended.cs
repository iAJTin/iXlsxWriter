
namespace iXlsxWriter.Operations.Result.Action;

public partial class ActionResultData
{
    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() => 
        $"{(OutputStream.Length > InputStream.Length ? "Modified" : "Default")}";
}
