
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    /// <summary>
    /// A Specialization of <see cref="NumericError"/> class.
    /// Represents the error structure for percentage data type. Allows us to set a default value and an additional comment.
    /// </summary>
    public partial class PercentageError : ICloneable
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

        #region [public] {new} (PercentageErrorModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new PercentageError Clone()
        {
            var percentageErrorCloned = (PercentageError) MemberwiseClone();
            percentageErrorCloned.Comment = Comment.Clone();
            percentageErrorCloned.Properties = Properties.Clone();

            return percentageErrorCloned;
        }         
        #endregion

        #endregion
    }
}
