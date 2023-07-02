
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Charting.Models.Design
{
    /// <summary>
    /// Represents the visual setting of chart size.
    /// </summary>
    public partial class CustomSizeModel : ICloneable
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultHeight = 1024;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultWidth = 768;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.SizeModel" /> class.
        /// </summary>
        public CustomSizeModel()
        {
            Height = DefaultHeight;
            Width = DefaultWidth;
        }

        #endregion

        #region interfaces

        #region ICloneable

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

        #region public static readonly members

        /// <summary>
        /// Returns default custom size <b>(1024, 768)</b>.
        /// </summary>
        public static readonly CustomSizeModel DefaultCustomSize = new();

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value that represents the preferred chart height. The default value is <b>1024</b>.
        /// </summary>
        /// <value>
        /// Preferred chart custom size.
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultHeight)]
        public int Height { get; set; }

        /// <summary>
        ///  Gets or sets a value that represents the preferred chart width. The default value is <b>1024</b>.
        /// </summary>
        /// <value>
        /// Preferred chart custom width.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultWidth)]
        public int Width { get; set; }

        #endregion

        #region public override properties

        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => Height.Equals(DefaultHeight) && Width.Equals(DefaultWidth);

        #endregion

        #region public methods

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public CustomSizeModel Clone() => (CustomSizeModel)MemberwiseClone();

        /// <summary>
        /// Returns a new Size structure that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size" /> that represents this instance.
        /// </returns>
        public Size ToSize() => new(Height, Width);

        #endregion

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";

        #endregion
    }
}
