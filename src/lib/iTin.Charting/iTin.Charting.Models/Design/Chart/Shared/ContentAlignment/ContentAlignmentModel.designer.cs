﻿
namespace iTin.Core.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    public partial class ContentAlignmentModel : BaseModel<ContentAlignmentModel>
    {
    }
}
