
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Charting.Models.Design
{
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
        public bool HorizontalSpecified => !Horizontal.IsDefault;

        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxesModel Parent { get; private set; }

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

        #region public properties

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
                _horizontal ??= new AxisDefinitionModel();
                _horizontal.SetParent(this);

                return _horizontal;
            }
            set => _horizontal = value;
        }

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
                _vertical ??= new AxisDefinitionModel();
                _vertical.SetParent(this);

                return _vertical;
            }
            set => _vertical = value;
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
        public override bool IsDefault => Horizontal.IsDefault && Vertical.IsDefault;

        #endregion

        #region public methods

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
        internal void SetParent(AxesModel reference)
        {
            Parent = reference;
        }

        #endregion
    }
}
