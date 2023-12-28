
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shared/v1.0")]
    public partial class XlsxStringRange : XlsxBaseRange
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && string.IsNullOrEmpty(Address);


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString() => Address;
    }
}
