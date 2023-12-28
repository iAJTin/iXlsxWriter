
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
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class XlsxStylesCollection : BaseComplexModelCollection<IXlsxStyle, object, string>
    {
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override IXlsxStyle GetBy(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return XlsxBaseStyle.Default;
            }

            var style = Find(s => s.Name.Equals(value));

            return style ?? XlsxCellStyle.Default;
        }


        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxStyle"/>.
        /// </summary>
        /// <param name="item">Reference to owner.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/></exception>
        protected override void SetOwner(IXlsxStyle item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
    }
}
