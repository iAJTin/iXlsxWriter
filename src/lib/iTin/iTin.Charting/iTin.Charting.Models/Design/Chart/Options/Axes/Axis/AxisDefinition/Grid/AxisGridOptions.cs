
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="AxisGridModel"/> instance.
    /// </summary>
    [Serializable]
    public class AxisGridOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] AxisDefinitionOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisDefinitionOptions"/> class.
        /// </summary>
        public AxisGridOptions()
        {
            MajorGrid = AxisGridDefinitionOptions.Default;
            MinorGrid = AxisGridDefinitionOptions.Default;
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

        #region [public] {static} (AxisGridOptions) Default: Gets a reference that contains the set of available settings to model an existing AxisGridModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="AxisGridModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static AxisGridOptions Default => new AxisGridOptions();
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
        public override bool IsDefault => MajorGrid.IsDefault && MinorGrid.IsDefault;
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) MajorGridSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MajorGridSpecified => !MajorGrid.IsDefault;
        #endregion

        #region [public] (bool) MinorGridSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MinorGridSpecified => !MinorGrid.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisGridDefinitionOptions) MajorGrid: Gets or sets a value that contains the line properties for a main grid axisin an existing AxisGridModel instance
        /// <summary>
        /// Gets or sets a value that contains the line properties for a main grid axisin an existing <see cref="AxisGridModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisGridDefinitionOptions"/> instance.
        /// </value>
        public AxisGridDefinitionOptions MajorGrid { get; set; }
        #endregion

        #region [public] (AxisGridDefinitionOptions) MinorGrid: Gets or sets a value that contains the line properties for a secondary grid axis in an existing AxisGridModel instance
        /// <summary>
        /// Gets or sets a value that contains the line properties for a secondary grid axis in an existing <see cref="AxisGridModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="AxisGridDefinitionOptions"/> instance.
        /// </value>
        public AxisGridDefinitionOptions MinorGrid { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (AxisGridOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisGridOptions Clone()
        {
            var clonned = (AxisGridOptions)MemberwiseClone();
            clonned.MajorGrid = MajorGrid.Clone();
            clonned.MinorGrid = MinorGrid.Clone();

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
