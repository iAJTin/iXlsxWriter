
namespace iTin.Core.Models.Design.Styling.Style.Content
{
    public partial class NumberDataType : ICombinable<NumberDataType>
    {
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content alignment</param>
        void ICombinable<NumberDataType>.Combine(NumberDataType reference) => Combine(reference);


        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(NumberDataType reference)
        {
            base.Combine(reference);

            if (Separator.Equals(DefaultSeparator))
            {
                Separator = reference.Separator;
            }
        }
    }
}
