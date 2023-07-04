
namespace iTin.Core.Models.Design.Styling.Style.Content
{
    public partial class TextDataType : ICombinable<TextDataType>
    {
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content alignment</param>
        void ICombinable<TextDataType>.Combine(TextDataType reference) => Combine(reference);


        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(TextDataType reference)
        {
        }
    }
}
