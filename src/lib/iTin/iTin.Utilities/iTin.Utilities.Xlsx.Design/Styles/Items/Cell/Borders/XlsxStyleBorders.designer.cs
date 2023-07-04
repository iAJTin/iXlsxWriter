
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0")]
    public partial class XlsxStyleBorders : BaseSimpleModelCollection<XlsxStyleBorder, XlsxBaseStyle>
    {
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxStyleBorder item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
    }
}
