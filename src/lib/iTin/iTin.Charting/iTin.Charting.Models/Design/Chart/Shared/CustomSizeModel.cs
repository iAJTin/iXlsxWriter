
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

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

        #region [public] SizeModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.SizeModel" /> class.
        /// </summary>
        public CustomSizeModel()
        {
            Height = DefaultHeight;
            Width = DefaultWidth;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #endregion

        #endregion

        #region public static readonly members
        /// <summary>
        /// Returns default custom size <b>(1024, 768)</b>.
        /// </summary>
        public static readonly CustomSizeModel DefaultCustomSize = new CustomSizeModel();
        #endregion

        #region public properties

        #region [public] (int) Height: Gets or sets a value that represents the preferred chart height
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
        #endregion

        #region [public] (int) Width: Gets or sets a value that represents the preferred chart width
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

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => Height.Equals(DefaultHeight) && Width.Equals(DefaultWidth);
        #endregion

        #endregion

        #region public methods

        #region [public] (CustomSizeModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public CustomSizeModel Clone() => (CustomSizeModel)MemberwiseClone();
        #endregion

        #region [public] (Size) ToSize(): Returns a new Size structure that represents this instance
        /// <summary>
        /// Returns a new Size structure that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size" /> that represents this instance.
        /// </returns>
        public Size ToSize() => new Size(Height, Width);
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current instance
        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion
    }
}
