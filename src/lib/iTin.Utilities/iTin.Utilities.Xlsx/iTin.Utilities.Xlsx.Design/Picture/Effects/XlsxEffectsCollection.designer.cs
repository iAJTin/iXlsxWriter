
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models.Collections;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/picture/v1.0")]
    public partial class XlsxEffectsCollection : BaseSimpleModelCollection<XlsxBaseEffect, XlsxPicture>
    {
    }
}
