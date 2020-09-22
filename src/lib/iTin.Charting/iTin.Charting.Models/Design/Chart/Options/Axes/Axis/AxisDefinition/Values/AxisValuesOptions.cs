
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="AxisValueModel"/> instance.
    /// </summary>
    [Serializable]
    public class AxisValuesOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] AxisValuesOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisValuesOptions"/> class.
        /// </summary>
        public AxisValuesOptions()
        {
            Interval = null;
            Maximun = null;
            Minimun = null;
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

        #region [public] {static} (AxisValuesOptions) Default: Gets a reference that contains the set of available settings to model an existing AxisValueModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="AxisValuesOptions"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static AxisValuesOptions Default => new AxisValuesOptions();
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
        public override bool IsDefault => Interval == null && Maximun == null && Minimun == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (float?) Interval: Gets or sets the interval between values of axis in an existing AxisLabelsModel instance
        /// <summary>
        /// Gets or sets the interval between values of axis in an existing <see cref="AxisLabelsModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Single"/> value that contains the interval values of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public float? Interval { get; set; }
        #endregion

        #region [public] (float?) Maximun: Gets or sets a value that represents the maximun value of axis expressed in tenths of a second in an existing AxisValueModel instance
        /// <summary>
        /// Gets or sets a value that represents the maximun value of axis expressed in tenths of a second in an existing <see cref="AxisValueModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Single"/> value that contains the maximun value of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public float? Maximun { get; set; }
        #endregion

        #region [public] (float?) Maximun: Gets or sets a value that represents the minimun value of axis expressed in tenths of a second in an existing AxisValueModel instance
        /// <summary>
        /// Gets or sets a value that represents the minimun value of axis expressed in tenths of a second in an existing <see cref="AxisValueModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="T:System.Single"/> value that contains the minimun value of axis.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public float? Minimun { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (AxisValuesOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisValuesOptions Clone() => (AxisValuesOptions)MemberwiseClone();
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
