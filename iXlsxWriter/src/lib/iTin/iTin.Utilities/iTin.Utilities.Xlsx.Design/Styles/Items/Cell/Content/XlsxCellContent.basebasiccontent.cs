
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContent
{
    #region public new readonly static properties

    /// <summary>
    /// Returns a new instance containing default cell content style settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellContent"/> reference containing the default cell content style settings.
    /// </value>
    public new static XlsxCellContent Default => new();

    #endregion

    #region public new readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new bool AlignmentSpecified => !Alignment.IsDefault;

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        Merge.IsDefault &&
        Pattern.IsDefault &&
        Alignment.IsDefault &&
        DataType.GetType() == typeof(TextDataType);

    #endregion
}
