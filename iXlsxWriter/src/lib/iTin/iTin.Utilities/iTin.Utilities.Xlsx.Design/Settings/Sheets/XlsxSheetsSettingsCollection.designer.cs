
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/settings/worksheets/v1.0")]
    public partial class XlsxSheetsSettingsCollection : BaseComplexModelCollection<XlsxSheetSettings, XlsxSettings, string>
    {
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override XlsxSheetSettings GetBy(string value) => Find(sheet => sheet.SheetName.Equals(value, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxSheetSettings item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
    }
}
