
using System;

using iXlsxWriter.ComponentModel.DataProvider;

namespace iXlsxWriter.ComponentModel.DataInput;

/// <summary>
/// Class than allows you to export an object of type <see cref="Uri"/>.
/// </summary>
[InputOptions(AdapterType = typeof(XmlProvider))]
public class JsonInput : BaseDataInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlInput"/> class.
    /// </summary>
    /// <param name="xml">The Xml.</param>
    public JsonInput(Uri xml)
        : base(xml)
    {
    }
}
