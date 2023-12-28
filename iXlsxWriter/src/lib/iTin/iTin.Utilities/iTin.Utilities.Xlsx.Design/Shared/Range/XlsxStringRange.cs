
using System;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
/// Represents a Excel cells range by alphaNumeric representation. Ex. "A1:B2", "A1", "$B$3:$F$33"
/// </summary>
public partial class XlsxStringRange
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _address;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the cell(s) address.
    /// </summary>
    /// <value>
    /// Horizontal cells
    /// </value>
    /// <exception cref="ArgumentNullException">The value specified is <b>null</b> (<b>Nothing</b> in Visual Basic) or empty.</exception>
    [XmlAttribute]
    [JsonProperty("address")]
    public string Address
    {
        get => _address;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(Address));
            _address = value;
        }
    }

    #endregion
}
