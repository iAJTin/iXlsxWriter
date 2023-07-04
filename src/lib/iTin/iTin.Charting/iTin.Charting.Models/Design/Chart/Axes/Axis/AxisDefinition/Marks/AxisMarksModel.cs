
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;

using iTin.Charting.Models.Design.Options;

namespace iTin.Charting.Models.Design;

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
    public bool MajorMarksSpecified => !MajorMarks.IsDefault;

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

    #region public properties

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
            _majorMarks ??= new AxisMarkModel();
            _majorMarks.SetParent(this);

            return _majorMarks;
        }
        set => _majorMarks = value;
    }

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
            _minorMarks ??= new AxisMarkModel();
            _minorMarks.SetParent(this);

            return _minorMarks;
        }
        set => _minorMarks = value;
    }

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

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault => MajorMarks.IsDefault && MinorMarks.IsDefault;

    #endregion

    #region public methods

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
