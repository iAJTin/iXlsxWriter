
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Charting.Models.Design.Options;

namespace iTin.Charting.Models.Design
{
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

        #region public readonly properties

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

        #region public properties

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
                _majorGrid ??= new AxisGridDefinitionModel();
                _majorGrid.SetParent(this);

                return _majorGrid;
            }
            set => _majorGrid = value;
        }

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
                _minorGrid ??= new AxisGridDefinitionModel();
                _minorGrid.SetParent(this);

                return _minorGrid;
            }
            set => _minorGrid = value;
        }

        #endregion

        #region public override properties

        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => MajorGrid.IsDefault && MinorGrid.IsDefault;

        #endregion

        #region public methods

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

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";

        #endregion

        #region internal methods

        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxisDefinitionModel reference)
        {
            Parent = reference;
        }

        #endregion
    }
}
