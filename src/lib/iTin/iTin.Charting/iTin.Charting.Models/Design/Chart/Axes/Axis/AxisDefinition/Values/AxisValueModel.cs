
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Charting.Models.Design.Options;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents the visual setting the values of a axis.
/// </summary>
public partial class AxisValueModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultMinimum = 0.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultInterval = 10.0f;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.AxisValueModel" /> class.
    /// </summary>
    public AxisValueModel()
    {
        Interval = DefaultInterval;
        Minimum = DefaultMinimum;
    }

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
    /// Gets or sets the interval value of axis expressed in tenths of a second. The default is <b>(10.0)</b>. 
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Single" /> that contains the interval value of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultInterval)]
    public float? Interval { get; set; }

    /// <summary>
    /// Gets or sets maximun value of axis expressed in tenths of a second.
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Single" /> that contains the maximun value of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public float? Maximum { get; set; }

    /// <summary>
    /// Gets or sets maximun value of axis expressed in tenths of a second. The default is <b>(0.0)</b>. 
    /// </summary>
    /// <value>
    /// A <see cref="T:System.String" /> that contains the minimun value of axis.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultMinimum)]
    public float? Minimum { get; set; }

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
    public override bool IsDefault => 
        Minimum.Equals(DefaultMinimum) && 
        Interval.Equals(DefaultInterval);

    #endregion

    #region public methods

    /// <summary>
    /// Apply specified options to this axis values.
    /// </summary>
    public void ApplyOptions(AxisValuesOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Interval

        float? intervalOption = options.Interval;
        bool intervalHasValue = intervalOption.HasValue;
        if (intervalHasValue)
        {
            Interval = intervalOption.Value;
        }

        #endregion

        #region Maximum

        float? maximumOption = options.Maximum;
        bool maximumHasValue = maximumOption.HasValue;
        if (maximumHasValue)
        {
            Maximum = maximumOption.Value;
        }

        #endregion

        #region Minimum

        float? minimumOption = options.Minimum;
        bool minimumHasValue = minimumOption.HasValue;
        if (minimumHasValue)
        {
            Minimum = minimumOption.Value;
        }

        #endregion
    }

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public AxisValueModel Clone()
    {
        var cloned = (AxisValueModel)MemberwiseClone();
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
