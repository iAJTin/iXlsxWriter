
using System;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// Represents a cell styles to use with data.
    /// </summary>
    public class DictionaryStyles : ICloneable
    {
        #region constructor/s

        #region [public] DictionaryStyles(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryStyles"/> class.
        /// </summary>
        public DictionaryStyles()
        {
            Headers = new DataStyles();
            Values = new DataStyles();
        }
        #endregion

        #endregion

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

        #region public properties

        #region [public] (DataStyles) Headers: Gets or sets the preferred cell headers styles
        /// <summary>
        /// Gets or sets the preferred cell headers styles.
        /// </summary>
        /// <value>
        /// Preferred cell headers styles.
        /// </value>
        public DataStyles Headers { get; set; }
        #endregion 

        #region [public] (DataStyles) Values: Gets or sets the preferred cell values styles
        /// <summary>
        /// Gets or sets the preferred cell values styles.
        /// </summary>
        /// <value>
        /// Preferred cell values styles.
        /// </value>
        public DataStyles Values { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (DictionaryStyles) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public DictionaryStyles Clone()
        {
            var cloned = (DictionaryStyles)MemberwiseClone();
            cloned.Headers = Headers.Clone();
            cloned.Values = Values.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
