
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;

namespace iTin.Core.Models.Design.Charting
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class ChartsCollection : BaseComplexModelCollection<BaseChart, object, string>
    {
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override BaseChart GetBy(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BaseChart.Default;
            }

            var style = Find(s => s.Name.Equals(value));

            return style ?? BaseChart.Default;
        }

        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(BaseChart item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
    }
}
