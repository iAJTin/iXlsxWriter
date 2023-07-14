
using System;
using System.ComponentModel;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design.Picture
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/picture/v1.0")]
    public partial class XlsxPicture : BaseModel<XlsxPicture>
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
            Effects.IsDefault &&
            Content.IsDefault &&
            ShapeEffects.IsDefault &&
            string.IsNullOrEmpty(Name) &&
            Show.Equals(DefaultShow);
    }
}
