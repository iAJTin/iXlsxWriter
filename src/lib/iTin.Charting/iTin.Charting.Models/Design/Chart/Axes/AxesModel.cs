
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Represents the visual setting for axes of a chart. Includes information of primary and secondary axes.
    /// </summary>
    public partial class AxesModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisModel _primary;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisModel _secondary;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownVerticalAxisPolicy DefaultVerticalAxisPolicy = KnownVerticalAxisPolicy.Auto;
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

        #region public properties

        #region [public] (ChartModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public ChartModel Parent { get; private set; }
        #endregion

        #region [public] (bool) PrimarySpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool PrimarySpecified => !Primary.IsDefault;
        #endregion

        #region [public] (bool) SecondarySpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool SecondarySpecified => !Secondary.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisModel) Primary: Gets or sets a reference to information of primary axes
        /// <summary>
        /// Gets or sets a reference to information of primary axes.
        /// </summary>
        /// <value>
        /// An <see cref="T:iTin.Export.Model.AxisModel" /> reference that contains information of primary axes. Includes information for the category and value axes.
        /// </value>
        public AxisModel Primary
        {
            get
            {
                if (_primary == null)
                {
                    _primary = new AxisModel();
                }

                _primary.SetParent(this);

                return _primary;
            }
            set => _primary = value;
        }
        #endregion

        #region [public] (AxisModel) Secondary: Gets or sets a reference to information of secondary axes
        /// <summary>
        /// Gets or sets a reference to information of secondary axes.
        /// </summary>
        /// <value>
        /// An <see cref="T:iTin.Export.Model.AxisModel" /> reference that contains information of secondary axes. Includes information for the category and value axes.
        /// </value>
        public AxisModel Secondary
        {
            get
            {
                if (_secondary == null)
                {
                    _secondary = new AxisModel();
                }

                _secondary.SetParent(this);

                return _secondary;
            }
            set => _secondary = value;
        }
        #endregion

        #region [public] (KnownVerticalAxisPolicy) VerticalAxisPolicy: Obtiene o establece un valor que indica la política a usar en los ejes verticales de cada serie
        /// <summary>
        /// Obtiene o establece un valor que indica la política a usar en los ejes verticales de cada serie. El valor predeterminado es <b>(KnownVerticalAxisPolicy.Auto)</b>.
        /// </summary>
        /// <value>
        /// Uno de los valores de la enumeración <see cref="KnownVerticalAxisPolicy"/>.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultVerticalAxisPolicy)]
        public KnownVerticalAxisPolicy VerticalAxisPolicy { get; set; }
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
        public override bool IsDefault => 
            Primary.IsDefault &&
            Secondary.IsDefault &&
            VerticalAxisPolicy.Equals(DefaultVerticalAxisPolicy);
        #endregion

        #endregion

        #region public methods

        #region [public] (AxesModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxesModel Clone()
        {
            var cloned = (AxesModel)MemberwiseClone();
            cloned.Primary.Clone();
            cloned.Secondary.Clone();
            cloned.SetParent(Parent);

            return cloned;
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

        #region internal methods

        #region [internal] (void) SetParent(ChartModel): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(ChartModel reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
