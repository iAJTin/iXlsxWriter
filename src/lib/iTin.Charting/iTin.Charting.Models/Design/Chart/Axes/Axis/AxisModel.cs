
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Includes information for the category and value axes.
    /// </summary>
    public partial class AxisModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisDefinitionModel _vertical;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisDefinitionModel _horizontal;
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

        #region public readonly properties

        #region [public] (bool) HorizontalSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool HorizontalSpecified => !Horizontal.IsDefault;
        #endregion

        #region [public] (AxesModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxesModel Parent { get; private set; }
        #endregion

        #region [public] (bool) VerticalSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool VerticalSpecified => !Vertical.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisDefinitionModel) Horizontal: Gets or sets a reference that contains the visual setting of category axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of category axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisDefinitionModel" /> reference that contains the visual setting of category axis. Allows you to configure the axis title, the axis labels, axis marks and axis values.
        /// </value>
        public AxisDefinitionModel Horizontal
        {
            get
            {
                if (_horizontal == null)
                {
                    _horizontal = new AxisDefinitionModel();
                }

                _horizontal.SetParent(this);

                return _horizontal;
            }
            set => _horizontal = value;
        }
        #endregion

        #region [public] (AxisDefinitionModel) Vertical: Gets or sets a reference that contains the visual setting of values axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of values axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisDefinitionModel" /> reference that contains the visual setting of values axis. Allows you to configure the axis title, the axis labels, axis marks and axis values.
        /// </value>
        public AxisDefinitionModel Vertical
        {
            get
            {
                if (_vertical == null)
                {
                    _vertical = new AxisDefinitionModel();
                }

                _vertical.SetParent(this);

                return _vertical;
            }
            set => _vertical = value;
        }
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
        public override bool IsDefault => Horizontal.IsDefault && Vertical.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (AxisDefinitionModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisModel Clone()
        {
            var cloned = (AxisModel)MemberwiseClone();
            cloned.Horizontal.Clone();
            cloned.Vertical.Clone();
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

        #region [internal] (void) SetParent(AxesModel): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxesModel reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
