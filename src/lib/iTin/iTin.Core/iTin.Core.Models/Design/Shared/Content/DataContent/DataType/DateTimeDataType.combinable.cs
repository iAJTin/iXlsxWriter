
namespace iTin.Core.Models.Design.Styling.Style.Content
{
    public partial class DateTimeDataType : ICombinable<DateTimeDataType>
    {
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content alignment</param>
        void ICombinable<DateTimeDataType>.Combine(DateTimeDataType reference) => Combine(reference);


        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(DateTimeDataType reference)
        {
            if (Locale.Equals(DefaultLocale))
            {
                Locale = reference.Locale;
            }

            if (Format.Equals(DefaultFormat))
            {
                Format = reference.Format;
            }

            Error.Combine(reference.Error);
        }
    }
}
