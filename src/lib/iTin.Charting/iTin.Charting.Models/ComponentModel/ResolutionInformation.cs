
namespace iTin.Charting.Models.ComponentModel
{
    using System;
    using System.Drawing;

     using Design;

   /// <summary>
    /// Represents the resolution information
    /// </summary>
    [Serializable]
    public class ResolutionInformation
    {
        /// <summary>
        /// Gets or sets chart resolution.
        /// </summary>
        /// <value>
        /// one of the values of the enumeration <see cref="KnownChartResolution"/>.
        /// </value>
        public KnownChartResolution Resolution { get; set; }

        /// <summary>
        /// Gets or sets aspect ratio of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the aspect ratio for a resolution.
        /// </value>
        public float AspectRatioValue { get; set; }

        /// <summary>
        /// Gets or sets <see cref="T:System.Drawing.Size" /> of a resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Drawing.Size" /> of a resolution.
        /// </value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value that contains the width of a resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Int32" /> that contains the width of a resolution.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets a value that contains the height of a resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Int32" /> that contains the height of a resolution.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the name of this resolution.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the name of a resolution.
        /// </value>
        public string Name { get; set;}

        /// <summary>
        /// Gets or sets aspect ratio of this resolution as textual format.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single" /> that contains the aspect ratio for a resolution as textual format.
        /// </value>
        public string AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets aspect ratio of this resolution as normalized value.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the aspect ratio for this resolution as normalized value.
        /// </value>
        public string AspectRatioNormalized { get; set; }
    }
}
