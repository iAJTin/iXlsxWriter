
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Charting.Models.Design;

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

    #region public properties

    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [Browsable(false)]
    [JsonIgnore]
    public ChartModel Parent { get; private set; }

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

    #region public properties

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
            _primary ??= new AxisModel();
            _primary.SetParent(this);

            return _primary;
        }
        set => _primary = value;
    }

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
            _secondary ??= new AxisModel();
            _secondary.SetParent(this);

            return _secondary;
        }
        set => _secondary = value;
    }

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

    #region public override properties

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

    #region public methods

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
    internal void SetParent(ChartModel reference)
    {
        Parent = reference;
    }

    #endregion
}
