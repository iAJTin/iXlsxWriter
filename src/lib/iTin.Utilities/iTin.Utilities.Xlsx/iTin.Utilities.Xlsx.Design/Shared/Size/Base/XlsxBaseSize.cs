
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// Base class for different sizes.<br/>
    /// Which acts as the base class for different size implementations.
    /// </summary>
    /// <remarks>
    ///   <para>The following table shows the different size implementations.</para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="XlsxPercentSize"/></term>
    ///       <description>Represents a size by percentual value.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxSize"/></term>
    ///       <description>Represents a size by width and height values.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxNullableSize"/></term>
    ///       <description>Represents a size by width and height optional values.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public abstract partial class XlsxBaseSize : ICloneable
    {
        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (KnownSizeType) Type: Gets a value indicating size type
        /// <summary>
        /// Gets a value indicating size type.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownSizeType"/> values.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public KnownSizeType Type
        {
            get
            {
                var addressType = GetType().Name;
                switch (addressType)
                {
                    case "XlsxPercentSize":
                        return KnownSizeType.Percent;

                    case "XlsxNullableSize":
                        return KnownSizeType.NullableSize;

                    default:
                        return KnownSizeType.Size;
                }
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBaseSize) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBaseSize Clone()
        {
            var cloned = (XlsxBaseSize)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
