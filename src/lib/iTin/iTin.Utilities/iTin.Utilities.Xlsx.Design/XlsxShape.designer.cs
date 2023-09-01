﻿
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shape/v1.0")]
    public partial class XlsxShape : BaseModel<XlsxShape>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Size.IsDefault &&
            Border.IsDefault &&
            Content.IsDefault &&
            ShapeEffects.IsDefault &&
            string.IsNullOrEmpty(Name) &&
            Show.Equals(DefaultShow) &&
            ShapeType.Equals(DefaultShapeType);
    }
}