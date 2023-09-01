
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design;

[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.itin.com/models/core/v1.0")]
[XmlRoot(Namespace = "http://schemas.itin.com/models/core/v1.0", IsNullable = false)]
public partial class XlsxTable : TableDefinition
{
    /// <inheritdoc/>
    [Browsable(false)]
    public override bool IsDefault =>
        base.IsDefault &&
        AutoFitColumns.Equals(DefaultAutoFitColumns);
}
