
namespace iTin.Charting.Models.ComponentModel
{
    using System;
    using System.Drawing;

    using Core.Helpers;
    using Design;

    /// <inheritdoc />
    /// <summary>
    /// Defines the additional information of a graphic resolution.
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ScreenResolutionAttribute : Attribute
    {
        #region public static properties

        #region [public] (ResolutionInformation) GetInformationFrom(KnownChartResolution): Returns the information about specified resolution
        /// <summary>
        /// Returns the information about specified resolution
        /// </summary>
        /// <param name="value">Chart resolution</param>
        /// <returns>
        /// A <see cref="ResolutionInformation"/> instance that contains the information about specified resolution.
        /// </returns>
        public static ResolutionInformation GetInformationFrom(KnownChartResolution value)
        {
            SentinelHelper.IsEnumValid(value);

            var type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field == null)
            {
                return null;
            }

            var attr = GetCustomAttribute(field, typeof(ScreenResolutionAttribute)) as ScreenResolutionAttribute;
            if (attr != null)
            {
                return new ResolutionInformation
                {
                    Size = attr.Size,
                    Name = attr.Name,
                    Width = attr.Width,
                    Resolution = value,
                    Height = attr.Height,
                    AspectRatio = attr.AspectRatio,
                    AspectRatioNormalized = attr.AspectRatioNormalized,
                    AspectRatioValue = attr.AspectRatioValue
                };
            }

            return null;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (float) AspectRatioValue: Gets aspect ratio of this resolution
        /// <summary>
        /// Gets aspect ratio of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the aspect ratio for this resolution.
        /// </value>
        public float AspectRatioValue
        {
            get
            {                
                string[] values = AspectRatio.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != 2)
                {
                    return float.NaN;
                }

                return float.Parse(values[0]) / float.Parse(values[1]);
            }
        }
        #endregion

        #region [public] (Size) Size: Gets size of this resolution
        /// <summary>
        /// Gets <see cref="T:System.Drawing.Size" /> of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Drawing.Size" /> of this resolution.
        /// </value>
        public Size Size => new Size(Width, Height);
        #endregion

        #region [public] (string) Name: Gets the name of this resolution
        /// <summary>
        /// Gets the name of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the name of this resolution.
        /// </value>
        public string Name { get; set; }
        #endregion

        #region [public] (int) Height: Gets the height of this resolution
        /// <summary>
        /// Gets a value that contains the height of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Int32" /> that contains the height of this resolution.
        /// </value>
        public int Height { get; set; }
        #endregion

        #region [public] (float) AspectRatio: Gets aspect ratio of this resolution as textual format
        /// <summary>
        /// Gets aspect ratio of this resolution as textual format.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the aspect ratio for this resolution as textual format.
        /// </value>
        public string AspectRatio { get; set; }
        #endregion

        #region [public] (string) AspectRatioNormalized: Gets aspect ratio of this resolution as normalized value.
        /// <summary>
        /// Gets aspect ratio of this resolution as normalized value.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the aspect ratio for this resolution as normalized value.
        /// </value>
        public string AspectRatioNormalized { get; set; }
        #endregion

        #region [public] (int) Width: Gets the name of this resolution
        /// <summary>
        /// Gets a value that contains the width of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Int32" /> that contains the width of this resolution.
        /// </value>
        public int Width { get; set; }
        #endregion

        #endregion
    }
}
