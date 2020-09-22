
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br />
    /// Treats the content as text and displays the content exactly as written, even when numbers are typed.
    /// </summary>
    public partial class TextDataType : ICloneable
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

        #region public new methods

        #region [public] {new} (TextDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public new TextDataType Clone()
        {
            var textDataTypeCloned = (TextDataType)MemberwiseClone();
            textDataTypeCloned.Properties = Properties.Clone();

            return textDataTypeCloned;
        }
        #endregion

        #endregion
    }
}
