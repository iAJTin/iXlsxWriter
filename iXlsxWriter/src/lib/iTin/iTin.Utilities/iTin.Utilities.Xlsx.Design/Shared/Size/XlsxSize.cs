
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
public partial class XlsxSize
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultHeight = 20;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultWidth = 20;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _height;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _width;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxSize"/> class.
    /// </summary>
    public XlsxSize()
    {
        Width = DefaultWidth;
        Height = DefaultHeight;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default size settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSize"/> reference containing the default size settings.
    /// </value>
    public static XlsxSize Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred height value. The default value is <b>20</b>.
    /// </summary>
    /// <value>
    /// Preferred height value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The specified value cannot be less than zero.</exception>
    [XmlElement]
    [JsonProperty("height")]
    public int Height
    {
        get => _height;
        set
        {
            SentinelHelper.ArgumentLessThan(nameof(Height), value, 0);

            _height = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred width value. The default value is <b>20</b>.
    /// </summary>
    /// <value>
    /// Preferred width value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The specified value cannot be less than zero.</exception>
    [XmlElement]
    [JsonProperty("width")]
    public int Width
    {
        get => _width;
        set
        {
            SentinelHelper.ArgumentLessThan(nameof(Width), value, 0);

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
    public override bool IsDefault => base.IsDefault && Height.Equals(DefaultHeight) && Width.Equals(DefaultWidth);

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxSize Clone()
    {
        var cloned = (XlsxSize)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion
}
