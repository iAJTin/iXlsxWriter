
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Table.Headers
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("System.Xml", "4.0.30319.18033")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class XlsxColumnsHeadersCollection : BaseComplexModelCollection<IXlsxColumnHeader, IParent, string>
    {
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override IXlsxColumnHeader GetBy(string value)
        {
            return this.Find(columnHeader => columnHeader.Equals(value));
        }

        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxColumnHeader"/>.
        /// </summary>
        /// <param name="item">Reference to owner.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/></exception>
        protected override void SetOwner(IXlsxColumnHeader item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
    }
}
