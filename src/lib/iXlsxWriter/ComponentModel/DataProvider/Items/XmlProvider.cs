
using System;
using System.Diagnostics;

namespace iXlsxWriter.ComponentModel.DataProvider;

/// <summary>
/// A Specialization of <see cref="BaseDataProvider"/><br/>
/// Represents a source object based on <strong>XML</strong>
/// </summary>
public class XmlProvider : BaseDataProvider
{
    #region private readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly char[] _monarchSpecialChars = { '#', '*', '@' };

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlProvider"/> class.
    /// </summary>
    /// <param name="inputUri">Target uri</param>
    public XmlProvider(Uri inputUri)
    {
        InputUri = inputUri;
        SpecialChars = _monarchSpecialChars;
    }

    #endregion
}
