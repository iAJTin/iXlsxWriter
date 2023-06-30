
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="AxisDefinitionModel"/> instance.
    /// </summary>
    [Serializable]
    public class AxisDefinitionOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] AxisDefinitionOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisDefinitionOptions"/> class.
        /// </summary>
        public AxisDefinitionOptions()
        {
            Name = null;
            LineColor = null;
            LineDashStyle = null;
            LineWidth = null;
            Show = null;

            Grid = AxisGridOptions.Default;
            Labels = AxisLabelsOptions.Default;
            Marks = AxisMarksOptions.Default;
            Title = AxisTitleOptions.Default;
            Values = AxisValuesOptions.Default;
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

        #region [public] {static} (AxisDefinitionOptions) Default: Gets a reference that contains the set of available settings to model an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static AxisDefinitionOptions Default => new AxisDefinitionOptions();
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
            Grid.IsDefault &&
            Labels.IsDefault &&
            LineColor == null &&
            LineDashStyle == null &&
            LineWidth == null &&
            Marks.IsDefault &&
            Name == null &&
            Show == null &&
            Title.IsDefault &&
            Values.IsDefault;
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) GridSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool GridSpecified => !Grid.IsDefault;
        #endregion

        #region [public] (bool) LabelsSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool LabelsSpecified => !Labels.IsDefault;
        #endregion

        #region [public] (bool) MarksSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MarksSpecified => !Marks.IsDefault;
        #endregion

        #region [public] (bool) TitleSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool TitleSpecified => !Title.IsDefault;
        #endregion

        #region [public] (bool) ValuesSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ValuesSpecified => !Values.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisGridOptions) Grid: Gets or sets a value that defines the grid configuration of the axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that defines the grid configuration of the axis in an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisGridOptions"/> instance.
        /// </value>
        public AxisGridOptions Grid { get; set; }
        #endregion

        #region [public] (AxisLabelsOptions) Labels: Gets or sets a value that defines the labels configuration of the axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that defines the labels configuration of the axis in an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisLabelsOptions"/> instance.
        /// </value>
        public AxisLabelsOptions Labels { get; set; }
        #endregion

        #region [public] (string) LineColor: Gets or sets the preferred line color of axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets the preferred line color of axis in an existing <see cref="AxisDefinitionModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or preferred line color of axis. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string LineColor { get; set; }
        #endregion

        #region [public] (KnownLineStyle?) LineDashStyle: Gets or sets a value that contains the axis line style in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that contains the axis line style in an existing <see cref="AxisDefinitionModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownLineStyle"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownLineStyle? LineDashStyle { get; set; }
        #endregion

        #region [public] (int?) LineWidth: Gets or sets a value that contains the axis line width in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that contains the axis line width in an existing <see cref="AxisDefinitionModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Int32"/> value that represents the line width in pixels. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public int? LineWidth { get; set; }
        #endregion

        #region [public] (AxisMarksOptions) Marks: Gets or sets a reference that contains the visual setting of mark axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of mark axis in an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisMarksOptions"/> instance.
        /// </value>
        public AxisMarksOptions Marks { get; set; }
        #endregion

        #region [public] (string) Name: Gets or sets a value that contains the axis identifier name in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that contains the axis identifier name in an existing <see cref="AxisDefinitionModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String"/> that contains the axis identifier name.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Name { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether displays the axis an existing AxisDefinitionModel instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether displays the axis an existing <see cref="AxisDefinitionModel"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (AxisTitleOptions) Title: Gets or sets a value that defines the grid configuration of the axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that defines the visual setting of axis title in an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisTitleOptions"/> instance.
        /// </value>
        public AxisTitleOptions Title { get; set; }
        #endregion

        #region [public] (AxisValuesOptions) Values: Gets or sets a value that defines the visual setting of values axis in an existing AxisDefinitionModel instance
        /// <summary>
        /// Gets or sets a value that defines the visual setting of values axis in an existing <see cref="AxisDefinitionModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisValuesOptions"/> instance.
        /// </value>
        public AxisValuesOptions Values { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (AxisDefinitionOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisDefinitionOptions Clone()
        {
            var clonned = (AxisDefinitionOptions)MemberwiseClone();
            clonned.Grid = Grid.Clone();
            clonned.Labels = Labels.Clone();
            clonned.Marks = Marks.Clone();
            clonned.Title = Title.Clone();
            clonned.Values = Values.Clone();

            return clonned;
        }
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
