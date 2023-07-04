
using System;
using System.Drawing;

using iTin.Charting.Models.Design;
using iTin.Core.Helpers;

namespace iTin.Charting.Models.ComponentModel;

/// <summary>
/// Defines the additional information of a graphic resolution.
/// </summary>
[Serializable]
[AttributeUsage(AttributeTargets.Field)]
public sealed class ScreenResolutionAttribute : Attribute
{
    #region public static properties

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

        if (GetCustomAttribute(field, typeof(ScreenResolutionAttribute)) is ScreenResolutionAttribute attr)
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

    #region public properties

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
            var values = AspectRatio.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 2)
            {
                return float.NaN;
            }

            return float.Parse(values[0]) / float.Parse(values[1]);
        }
    }

    /// <summary>
    /// Gets <see cref="System.Drawing.Size" /> of this resolution.
    /// </summary>
    /// <value>
    /// A <see cref="System.Drawing.Size" /> of this resolution.
    /// </value>
    public Size Size => new(Width, Height);

    /// <summary>
    /// Gets the name of this resolution.
    /// </summary>
    /// <value>
    /// A <see cref="string" /> that contains the name of this resolution.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets a value that contains the height of this resolution.
    /// </summary>
    /// <value>
    /// A <see cref="int" /> that contains the height of this resolution.
    /// </value>
    public int Height { get; set; }

    /// <summary>
    /// Gets aspect ratio of this resolution as textual format.
    /// </summary>
    /// <value>
    /// A <see cref="string" /> that contains the aspect ratio for this resolution as textual format.
    /// </value>
    public string AspectRatio { get; set; }

    /// <summary>
    /// Gets aspect ratio of this resolution as normalized value.
    /// </summary>
    /// <value>
    /// A <see cref="string" /> that contains the aspect ratio for this resolution as normalized value.
    /// </value>
    public string AspectRatioNormalized { get; set; }

    /// <summary>
    /// Gets a value that contains the width of this resolution.
    /// </summary>
    /// <value>
    /// A <see cref="int" /> that contains the width of this resolution.
    /// </value>
    public int Width { get; set; }

    #endregion
}
