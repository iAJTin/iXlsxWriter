
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
    public partial class XlsxRange : XlsxBaseRange
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            End.IsDefault &&
            Start.IsDefault;


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var startRowNumber = Start.AbsoluteStrategy is AbsoluteStrategy.Both or AbsoluteStrategy.Row ? $"${Start.Row}" : $"{Start.Row}";
            var startColumnLetter = GetColumnLetter(Start.Column, Start.AbsoluteStrategy is AbsoluteStrategy.Column or AbsoluteStrategy.Both);
            var start = $"{startColumnLetter}{startRowNumber}";

            var endRowNumber = End.AbsoluteStrategy is AbsoluteStrategy.Both or AbsoluteStrategy.Row ? $"${End.Row}" : $"{End.Row}";
            var endColumnLetter = GetColumnLetter(End.Column, End.AbsoluteStrategy is AbsoluteStrategy.Column or AbsoluteStrategy.Both);
            var end = $"{endColumnLetter}{endRowNumber}";

            return $"{start}:{end}";
        }
    }
}
