
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/settings/worksheets/v1.0")]
    public partial class XlsxSheetSettings : BaseModel<XlsxSheetSettings>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool IsDefault =>
            base.IsDefault &&
            Footer.IsDefault &&
            Header.IsDefault &&
            Margins.IsDefault &&
            View.Equals(DefaultView) &&
            Size.Equals(DefaultSize) &&
            string.IsNullOrEmpty(SheetName) &&
            Orientation.Equals(DefaultOrientation);
    }
}
