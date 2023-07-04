
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines <b>xlsx</b> sheet margins.
/// </summary>
public partial class XlsxDocumentMargins : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultTop = 20f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultLeft = 20f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultRight = 20f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultBottom = 20f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownUnit DefaultUnits = KnownUnit.Millimeters;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _top;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _right;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _bottom;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _left;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownUnit _unit;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentMargins"/> class.
    /// </summary>
    public XlsxDocumentMargins()
    {
        Top = DefaultTop;
        Left = DefaultLeft;
        Right = DefaultRight;
        Bottom = DefaultBottom;
        Units = DefaultUnits;
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc/>
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing document margins settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMargins"/> reference containing the default document margins settings.
    /// </value>
    public static XlsxDocumentMargins Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred bottom margin of document. The default is <b>20.0</b>.
    /// </summary>
    /// <value>
    /// Preferred bottom margin of document.
    /// </value>
    /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
    [XmlAttribute]
    [DefaultValue(DefaultBottom)]
    [JsonProperty("bottom")]
    public float Bottom
    {
        get => _bottom;
        set
        {
            SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

            _bottom = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred left margin of document. The default is <b>20.0</b>.
    /// </summary>
    /// <value>
    /// Preferred left margin of document. 
    /// </value>
    /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
    [XmlAttribute]
    [JsonProperty("left")]
    [DefaultValue(DefaultLeft)]
    public float Left
    {
        get => _left;
        set
        {
            SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

            _left = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred right margin of document. The default is <b>20.0</b>.
    /// </summary>
    /// <value>
    /// Preferred right margin of document. 
    /// </value>
    /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
    [XmlAttribute]
    [JsonProperty("right")]
    [DefaultValue(DefaultRight)]
    public float Right
    {
        get => _right;
        set
        {
            SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

            _right = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred top margin of document. The default is <b>20.0</b>.
    /// </summary>
    /// <value>
    /// Preferred top margin of document.
    /// </value>
    /// <exception cref="InvalidOperationException">The value specified cannot be less than zero.</exception>
    [XmlAttribute]
    [JsonProperty("top")]
    [DefaultValue(DefaultTop)]
    public float Top
    {
        get => _top;
        set
        {
            SentinelHelper.IsTrue(value < 0, "The margin cannot be less than zero");

            _top = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred units of margins. The default is <see cref="KnownUnit.Millimeters"/>.
    /// </summary>
    /// <value>
    /// Preferred units of margins. 
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [DefaultValue(DefaultUnits)]
    public KnownUnit Units
    {
        get => _unit;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _unit = value;
        }
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        Top.Equals(DefaultTop) &&
        Right.Equals(DefaultRight) &&
        Left.Equals(DefaultLeft) &&
        Bottom.Equals(DefaultBottom) &&
        Units.Equals(DefaultUnits);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxDocumentMargins Clone()
    {
        var cloned = (XlsxDocumentMargins) MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentMargins reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Bottom.Equals(DefaultBottom))
        {
            Bottom = reference.Bottom;
        }

        if (Left.Equals(DefaultLeft))
        {
            Left = reference.Left;
        }

        if (Right.Equals(DefaultRight))
        {
            Right = reference.Right;
        }

        if (Top.Equals(DefaultTop))
        {
            Top = reference.Top;
        }

        if (Units.Equals(DefaultUnits))
        {
            Units = reference.Units;
        }
    }

    #endregion
}
