
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="AxisGridDefinitionModel"/> instance.
    /// </summary>
    [Serializable]
    public class AxisGridDefinitionOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] AxisGridDefinitionOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisGridDefinitionOptions"/> class.
        /// </summary>
        public AxisGridDefinitionOptions()
        {
            Interval = null;
            LineColor = null;
            LineDashStyle = null;
            LineWidth = null;
            Show = null;
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

        #region public static properties

        #region [public] {static} (AxisGridDefinitionOptions) Default: Gets a reference that contains the set of available settings to model an existing AxisGridDefinitionModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="AxisGridDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static AxisGridDefinitionOptions Default => new AxisGridDefinitionOptions();
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Interval == null &&
            LineColor == null &&
            LineDashStyle == null &&
            LineWidth == null &&
            Show == null;
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (float?) Interval: Gets or setsthe interval between the main or secondary grid lines in an existing AxisGridDefinitionModel instance
        /// <summary>
        /// Gets or setsthe interval between the main or secondary grid lines in an existing <see cref="AxisGridDefinitionModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Single"/> value that represents the interval between the grid lines.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public float? Interval { get; set; }
        #endregion

        #region [public] (string) LineColor: Gets or sets the preferred line color of axis in an existing AxisGridDefinitionModel instance
        /// <summary>
        ///  Gets or sets the preferred line color of axis in an existing <see cref="AxisGridDefinitionModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or preferred line color of axis. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string LineColor { get; set; }
        #endregion

        #region [public] (KnownLineStyle?) LineDashStyle: Gets or sets a value that contains the axis line style in an existing AxisGridDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that contains the axis line style in an existing <see cref="AxisGridDefinitionModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownLineStyle"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownLineStyle? LineDashStyle { get; set; }
        #endregion

        #region [public] (int?) LineWidth: Gets or sets a value that contains the axis line width in an existing AxisGridDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that contains the axis line width in an existing <see cref="AxisGridDefinitionModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Int32"/> value that represents the line width in pixels. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public int? LineWidth { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether displays the axis an existing AxisGridDefinitionModel instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether displays the axis an existing <see cref="AxisGridDefinitionModel"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo? Show { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (AxisGridDefinitionOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisGridDefinitionOptions Clone() => (AxisGridDefinitionOptions)MemberwiseClone();
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
