
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Drawing.ComponentModel;
using iTin.Core.Helpers;

namespace iTin.Core.Models.Design;

/// <summary>
/// Flip mode for an image.
/// </summary>
/// <remarks>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Flip .../>
/// ]]>
/// </code>
/// <para><strong><u>Attributes</u></strong></para>
/// <table>
///   <thead>
///     <tr>
///       <th>Attribute</th>
///       <th>Optional</th>
///       <th>Description</th>
///       </tr>
///   </thead>
///   <tbody>
///     <tr>
///       <td><see cref="Mode"/></td>
///       <td align="center">Yes</td>
///       <td>Preferred flip style to apply to an image. The default is <see cref="FlipStyle.None"/>.</td>
///     </tr>
///   </tbody>
/// </table>
/// </remarks>
public partial class Flip
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const FlipStyle DefaultMode = FlipStyle.None;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FlipStyle _mode;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="Flip"/> class.
    /// </summary>
    public Flip()
    {
        Mode = DefaultMode;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred flip style to apply to an image.
    /// </summary>
    /// <value>
    /// Preferred flip style to apply to an image. The default is <see cref="FlipStyle.None"/>.
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Flip Mode="None|X|Y|XY"/>
    /// ]]>
    /// </code>
    /// </remarks>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultMode)]
    public FlipStyle Mode
    {
        get => _mode;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _mode = value;
        }
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [Browsable(false)]
    public override bool IsDefault => 
        base.IsDefault &&
        Mode.Equals(DefaultMode);

    #endregion
}
