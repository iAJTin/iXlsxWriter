
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Options;

    /// <summary>
    /// Represents the visual setting the lines for a marks axis.
    /// </summary>
    public partial class AxisMarksModel : ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisMarkModel _majorMarks;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisMarkModel _minorMarks;
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

        #region [public] (bool) MajorMarksSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MajorMarksSpecified => !MajorMarks.IsDefault;
        #endregion

        #region [public] (bool) MinorMarksSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MinorMarksSpecified => !MinorMarks.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisMarkModel) MajorMarks: Gets or sets a reference that contains the line properties for a main marks axis
        /// <summary>
        /// Gets or sets a reference that contains the line properties for a main marks axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisMarkModel" /> reference that contains the line properties for a main marks axis.
        /// </value>
        public AxisMarkModel MajorMarks
        {
            get
            {
                if (_majorMarks == null)
                {
                    _majorMarks = new AxisMarkModel();
                }

                _majorMarks.SetParent(this);

                return _majorMarks;
            }
            set => _majorMarks = value;
        }
        #endregion

        #region [public] (AxisMarkModel) MinorMarks: Gets or sets a reference that contains the line properties for a secondary marks axis
        /// <summary>
        /// Gets or sets a reference that contains the line properties for a secondary marks axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisMarkModel" /> reference that contains the line properties for a secondary marks axis.
        /// </value>
        public AxisMarkModel MinorMarks
        {
            get
            {
                if (_minorMarks == null)
                {
                    _minorMarks = new AxisMarkModel();
                }

                _minorMarks.SetParent(this);

                return _minorMarks;
            }
            set => _minorMarks = value;
        }
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

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => MajorMarks.IsDefault && MinorMarks.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(AxisMarksOptions): Apply specified options to this axis marks
        /// <summary>
        /// Apply specified options to this axis marks.
        /// </summary>
        public void ApplyOptions(AxisMarksOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region MajorMarks
            MajorMarks.ApplyOptions(options.MajorMarks);
            #endregion

            #region MinorMarks
            MinorMarks.ApplyOptions(options.MinorMarks);
            #endregion
        }
        #endregion

        #region [public] (AxisMarksModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisMarksModel Clone()
        {
            var cloned = (AxisMarksModel)MemberwiseClone();
            cloned.MajorMarks = MajorMarks.Clone();
            cloned.MinorMarks = MinorMarks.Clone();
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
