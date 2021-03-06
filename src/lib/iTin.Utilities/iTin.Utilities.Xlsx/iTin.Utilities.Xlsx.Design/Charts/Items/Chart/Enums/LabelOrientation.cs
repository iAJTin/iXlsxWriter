﻿
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the orientation of labels on the axis.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LabelOrientation
    {
        /// <summary>
        /// The orientation is automatic.
        /// </summary>
        Automatic,

        /// <summary>
        /// The orientation is downward.
        /// </summary>
        Downward,

        /// <summary>
        /// The orientation is horizontal.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The orientation is upward.
        /// </summary>
        Upward,

        /// <summary>
        /// The orientation is vertical.
        /// </summary>
        Vertical
    }
}
