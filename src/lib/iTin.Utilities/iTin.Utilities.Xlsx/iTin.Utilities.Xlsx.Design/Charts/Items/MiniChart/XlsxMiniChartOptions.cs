
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChart"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxMiniChartOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxMiniChartOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartOptions"/> class.
        /// </summary>
        public XlsxMiniChartOptions()
        {
            ChartAxes = null;
            ChartSize = null;
            //ChartType = null;
            EmptyValueAs = null;
            DisplayHidden = null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
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

        #region [public] {static} (XlsxMiniChartOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxMiniChart instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChart"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxMiniChartOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxMiniChart"/> instance.
        /// </value>
        public static XlsxMiniChartOptions Default => new XlsxMiniChartOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) ChartAxesSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ChartAxesSpecified => ChartAxes != null;
        #endregion

        #region [public] (bool) ChartSizeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ChartSizeSpecified => ChartSize != null;
        #endregion

        //#region [public] (bool) ChartTypeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        ///// <summary>
        ///// Gets a value that tells the serializer if the referenced item is to be included.
        ///// </summary>
        ///// <value>
        ///// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        ///// </value>
        //[JsonIgnore]
        //[XmlIgnore]
        //Browsable(false)]
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public bool ChartTypeSpecified => ChartType != null;
        //#endregion

        #endregion

        #region public properties

        #region [public] (XlsxMiniChartAxesOptions) ChartAxes: Gets or sets a value that contains the visual setting in an existing XlsxMiniChart instance
        /// <summary>
        /// Gets or sets a value that contains the visual setting in an existing <see cref="XlsxMiniChart"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartAxesOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-axes")]
        public XlsxMiniChartAxesOptions ChartAxes { get; set; }
        #endregion

        #region [public] (XlsxMiniChartSizeOptions) ChartSize: Gets or sets the preferred cell size in an existing in an existing XlsxMiniChart instance
        /// <summary>
        /// Gets or sets the preferred chart size in an existing <see cref="XlsxMiniChart"/>" instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartSizeOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-size")]
        public XlsxMiniChartSizeOptions ChartSize { get; set; }
        #endregion

        //#region [public] (XlsxMiniChartChartTypeOptions) ChartType: Gets or sets a reference that contains the visual setting in an existing XlsxMiniChart instance
        ///// <summary>
        ///// Gets or sets a reference that contains the visual setting in an existing <see cref="XlsxMiniChart"/> instance.
        ///// </summary>
        ///// <value>
        ///// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartAxesOptions"/> instance.
        ///// </value>
        //[XmlElement]
        //[JsonProperty("chart-type")]
        //public XlsxMiniChartChartTypeOptions ChartType { get; set; }
        //#endregion

        #region [public] (YesNo?) DisplayHidden: Gets or sets the preferred action for display hidden values in an existing XlsxMiniChart instance
        /// <summary>
        /// Gets or sets the preferred action for display hidden values in an existing <see cref="XlsxMiniChart"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="YesNo"/>. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("display-hidden")]
        public YesNo? DisplayHidden { get; set; }
        #endregion

        #region [public] (MiniChartEmptyValuesAs?) EmptyValueAs: Gets or sets the preferred action when the field does not contain information in an existing XlsxMiniChart instance
        /// <summary>
        /// Gets or sets the preferred action when the field does not contain information in an existing <see cref="XlsxMiniChart"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="MiniChartEmptyValuesAs"/>. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("empty-value")]
        public MiniChartEmptyValuesAs? EmptyValueAs { get; set; }
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
            base.IsDefault &&
            ChartAxes == null &&
            ChartSize == null &&
            //ChartType == null &&
            EmptyValueAs == null &&
            DisplayHidden == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartOptions Clone()
        {
            var cloned = (XlsxMiniChartOptions) MemberwiseClone();

            if (ChartAxes != null)
            {
                cloned.ChartAxes = ChartAxes.Clone();
            }

            if (ChartSize != null)
            {
                cloned.ChartSize = ChartSize.Clone();
            }
            
            //if (ChartType != null)
            //{
            //    cloned.ChartType = ChartType.Clone();
            //}

            return cloned;
        } 
        #endregion

        #endregion
    }
}
