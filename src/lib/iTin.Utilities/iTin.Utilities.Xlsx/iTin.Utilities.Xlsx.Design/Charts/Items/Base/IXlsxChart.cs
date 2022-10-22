
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Charting;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// A Specialization of <see cref="IChart"/> interface.<br/>
    /// Defines a generic <b>xlsx</b> chart.
    /// </summary>
    public interface IXlsxChart : IChart, ICombinable<IXlsxChart>
    {
        /// <summary>
        /// Gets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IXlsxCharts"/> that owns this <see cref="IXlsxChart"/>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        new IXlsxCharts Owner { get; }


        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxChart"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        void SetOwner(IXlsxCharts reference);
    }
}
