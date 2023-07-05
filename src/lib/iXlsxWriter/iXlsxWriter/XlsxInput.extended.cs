
using iXlsxWriter.ComponentModel;

namespace iXlsxWriter;

public partial class XlsxInput
{
    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() =>
        InputType switch
        {
            KnownInputType.Filename => $"Input='{Input}', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.XlsxInput => $"Input='XlsxInput', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.Stream => $"Input='Stream', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.ByteArray => $"Input='Byte[]', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.NotSupported => "Input type not supported",
            _ => $"Type={InputType}, Updatable={AutoUpdateChanges}",
        };
}
