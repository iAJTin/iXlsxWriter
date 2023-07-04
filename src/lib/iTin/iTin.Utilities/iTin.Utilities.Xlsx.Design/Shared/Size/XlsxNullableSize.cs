
using System;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseSize"/> class.<br/>
/// Represents a size by width and height values
/// </summary>
public partial class XlsxNullableSize
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int? _height;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int? _width;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxNullableSize"/> class.
    /// </summary>
    public XlsxNullableSize()
    {
        Width = null;
        Height = null;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred height value. If the value is <b>null</b>, the current value is maintained. The default value is <b>null</b> (<b>Nothing</b> in Visual Basic).
    /// </summary>
    /// <value>
    /// Preferred height value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The specified value cannot be less than zero.</exception>
    [XmlElement]
    [JsonProperty("height")]
    public int? Height
    {
        get => _height;
        set
        {
            var hasValue = value.HasValue;
            if (hasValue)
            {
                SentinelHelper.ArgumentLessThan(nameof(Height), value.Value, 0);
            }

            _height = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred width value. If the value is <b>null</b>, the current value is maintained. The default value is <b>null</b> (<b>Nothing</b> in Visual Basic).
    /// </summary>
    /// <value>
    /// Preferred width value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The specified value cannot be less than zero.</exception>
    [XmlElement]
    [JsonProperty("width")]
    public int? Width
    {
        get => _width;
        set
        {
            var hasValue = value.HasValue;
            if (hasValue)
            {
                SentinelHelper.ArgumentLessThan(nameof(Width), value.Value, 0);
            }

            _width = value;
        }
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Height == null && Width == null;

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxNullableSize Clone()
    {
        var cloned = (XlsxNullableSize)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion
}
