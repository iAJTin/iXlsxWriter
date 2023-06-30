
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Options;

    /// <summary>
    /// Represents the visual setting the lines for a grid axis.
    /// </summary>
    public partial class AxisGridModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisGridDefinitionModel _majorGrid;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisGridDefinitionModel _minorGrid;
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

        #region [public] (AxisDefinitionModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxisDefinitionModel Parent { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisGridDefinitionModel) MajorGrid: Gets or sets a reference that contains the line properties for a main grid axis
        /// <summary>
        /// Gets or sets a reference that contains the line properties for a main grid axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisGridDefinitionModel" /> reference that contains the line properties for a main grid axis.
        /// </value>
        public AxisGridDefinitionModel MajorGrid
        {
            get
            {
                if (_majorGrid == null)
                {
                    _majorGrid = new AxisGridDefinitionModel();
                }

                _majorGrid.SetParent(this);

                return _majorGrid;
            }
            set => _majorGrid = value;
        }
        #endregion

        #region [public] (AxisGridDefinitionModel) MinorGrid: Gets or sets a reference that contains the line properties for a secondary grid axis
        /// <summary>
        /// Gets or sets a reference that contains the line properties for a secondary grid axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisGridDefinitionModel" /> reference that contains the line properties for a secondary grid axis.
        /// </value>
        public AxisGridDefinitionModel MinorGrid
        {
            get
            {
                if (_minorGrid == null)
                {
                    _minorGrid = new AxisGridDefinitionModel();
                }

                _minorGrid.SetParent(this);

                return _minorGrid;
            }
            set => _minorGrid = value;
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
        public override bool IsDefault => MajorGrid.IsDefault && MinorGrid.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(AxisGridOptions): Apply specified options to this axis grid
        /// <summary>
        /// Apply specified options to this axis grid.
        /// </summary>
        public void ApplyOptions(AxisGridOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region MajorGrid
            MajorGrid.ApplyOptions(options.MajorGrid);
            #endregion

            #region MinorMarks
            MinorGrid.ApplyOptions(options.MinorGrid);
            #endregion
        }
        #endregion

        #region [public] (AxisGridModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisGridModel Clone()
        {
            var cloned = (AxisGridModel)MemberwiseClone();
            cloned.MajorGrid = MajorGrid.Clone();
            cloned.MinorGrid = MinorGrid.Clone();
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

        #region [internal] (void) SetParent(AxisDefinitionModel): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxisDefinitionModel reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
