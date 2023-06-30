
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    /// <summary>
    /// A Specialization of <see cref="NumericError"/> class.
    /// Represents the error structure for scientific data type. Allows us to set a default value and an additional comment.
    /// </summary>
    public partial class ScientificError : ICloneable
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

        #region [public] {new} (ScientificErrorModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new ScientificError Clone()
        {
            var scientificErrorCloned = (ScientificError)MemberwiseClone();
            scientificErrorCloned.Comment = Comment.Clone();
            scientificErrorCloned.Properties = Properties.Clone();

            return scientificErrorCloned;
        }
        #endregion

        #endregion
    }
}
