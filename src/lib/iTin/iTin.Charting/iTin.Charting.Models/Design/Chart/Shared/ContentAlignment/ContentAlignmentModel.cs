
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Helpers;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines content alignment.
/// </summary>
public partial class ContentAlignmentModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownVerticalAlignment DefaultVerticalAlignment = KnownVerticalAlignment.Top;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownHorizontalAlignment DefaultHorizontalAlignment = KnownHorizontalAlignment.Center;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownVerticalAlignment _vertical;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownHorizontalAlignment _horizontal;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentAlignmentModel"/> class.
    /// </summary>
    public ContentAlignmentModel()
    {
        Vertical = DefaultVerticalAlignment;
        Horizontal = DefaultHorizontalAlignment;
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

    #region public static properties

    /// <summary>
    /// Gets default alignament.
    /// </summary>
    /// <value>
    /// Default alignament
    /// </value>
    public static ContentAlignmentModel Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets horizontal alignment. The default is <b>(<see cref="KnownHorizontalAlignment.Center"/>)</b>.
    /// </summary>
    /// <value>
    /// One of the <see cref="KnownHorizontalAlignment"/> values.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultHorizontalAlignment)]
    [JsonConverter(typeof(StringEnumConverter))]
    public KnownHorizontalAlignment Horizontal
    {
        get => _horizontal;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _horizontal = value;
        }
    }

    /// <summary>
    /// Gets or sets vertical alignment. The default is <b>(<see cref="KnownVerticalAlignment.Top"/>)</b>.
    /// </summary>
    /// <value>
    /// One of the <see cref="KnownVerticalAlignment"/> values.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultVerticalAlignment)]
    [JsonConverter(typeof(StringEnumConverter))]
    public KnownVerticalAlignment Vertical
    {
        get => _vertical;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _vertical = value;
        }
    }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => Vertical.Equals(DefaultVerticalAlignment) && Horizontal.Equals(DefaultHorizontalAlignment);

    #endregion

    #region public methods

    /// <summary>
    /// Apply specified options to this font.
    /// </summary>
    public void ApplyOptions(ContentAlignmentOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Horizontal
        KnownHorizontalAlignment? horizontalOption = options.Horizontal;
        bool horizontalHasValue = horizontalOption.HasValue;
        if (horizontalHasValue)
        {
            Horizontal = horizontalOption.Value;
        }
        #endregion

        #region Vertical
        KnownVerticalAlignment? verticalOption = options.Vertical;
        bool verticalHasValue = verticalOption.HasValue;
        if (verticalHasValue)
        {
            Vertical = verticalOption.Value;
        }
        #endregion
    }

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public ContentAlignmentModel Clone() => (ContentAlignmentModel)MemberwiseClone();

    #endregion
}
