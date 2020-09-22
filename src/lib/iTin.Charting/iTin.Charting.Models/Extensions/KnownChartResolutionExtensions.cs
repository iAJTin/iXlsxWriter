
namespace iTin.Charting.Models
{
    using System;

    using iTin.Core.Helpers;

    using ComponentModel;
    using Design;

    /// <summary>
    /// Defines extension methods for <see cref="ScreenResolutionAttribute"/> enumerated type.
    /// </summary>
    public static class KnownChartResolutionExtensions
    {
        /// <summary>
        /// Returns the value of attribute of type <see cref="ScreenResolutionAttribute"/> for this enum value. 
        /// If this attribute is not defined returns <b>null</b> (<b>Nothing</b> in Visual Basic)
        /// </summary>
        /// <param name="value">Target enum value.</param>
        /// <returns>
        /// A <see cref="ResolutionInformation"/> that contains the value of attribute.
        /// </returns>
        public static ResolutionInformation GetResolutionInformation(this KnownChartResolution value)
        {
            SentinelHelper.IsEnumValid(value);

            var type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field == null)
            {
                return null;
            }

            var attr = Attribute.GetCustomAttribute(field, typeof(ScreenResolutionAttribute)) as ScreenResolutionAttribute;
            return attr != null 
                ? ScreenResolutionAttribute.GetInformationFrom(value) 
                : null;
        }
    }
}
