﻿
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseSize"/> class.<br/>
/// Represents a size by percentual value.
/// </summary>
public partial class XlsxPercentSize
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultPercent = 100.0f;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _percent;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPercentSize"/> class.
    /// </summary>
    public XlsxPercentSize()
    {
        Value = DefaultPercent;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred percent value, expresed in %. The default value is <b>100.0</b>.
    /// </summary>
    /// <value>
    /// Preferred percent value
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
    [XmlAttribute]
    [JsonProperty("value")]
    [DefaultValue(DefaultPercent)]
    public float Value
    {
        get => _percent;
        set
        {
            SentinelHelper.ArgumentOutOfRange("Value", value, 0.0f, 100.0f, "The value must be between 0 and 100");

            _percent = value;
        }
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Value.Equals(DefaultPercent);

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxPercentSize Clone()
    {
        var cloned = (XlsxPercentSize)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion
}
