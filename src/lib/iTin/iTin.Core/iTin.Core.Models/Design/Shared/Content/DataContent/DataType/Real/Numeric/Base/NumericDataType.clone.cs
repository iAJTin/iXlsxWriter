
using System;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    public partial class NumericDataType : ICloneable
    {
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();


        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public new NumericDataType Clone()
        {
            var numericDataCloned = (NumericDataType)MemberwiseClone();
            numericDataCloned.Error = Error.Clone();
            numericDataCloned.Negative = Negative.Clone();
            numericDataCloned.Properties = Properties.Clone();

            return numericDataCloned;
        }
    }
}
