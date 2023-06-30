
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Styling;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="IStyle"/> interface.<br/>
    /// Defines a generic <b>xlsx</b> style.
    /// </summary>
    public interface IXlsxStyle : IStyle, ICombinable<IXlsxStyle>
    {
        /// <summary>
        /// Gets the element that owns this <see cref="IXlsxStyle"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IXlsxStyles"/> that owns this <see cref="IXlsxStyle"/>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        new IXlsxStyles Owner { get; }


        /// <summary>
        /// Sets the element that owns this <see cref="IXlsxStyle"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        void SetOwner(IXlsxStyles reference);
    }
}
