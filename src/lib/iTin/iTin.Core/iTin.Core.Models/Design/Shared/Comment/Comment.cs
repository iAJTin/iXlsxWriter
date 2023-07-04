
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// Represents a comment. Includes comment text, format, including font face, size, and style attributes.
/// </summary>
/// <remarks>
/// <para><strong><u>Usage</u></strong>:</para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Comment>
///   <Text/>
///   <Font/>
/// </Comment>
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
///       <td><see cref="Show"/></td>
///       <td align="center">Yes</td>
///       <td>Determines whether displays a comment that contains the original value of the field. The default is <see cref="YesNo.Yes"/>.</td>
///     </tr>
///   </tbody>
/// </table>
/// <para><strong><u>Elements</u></strong></para>
/// <list type="table">
///   <listheader>
///     <term>Element</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="Font"/></term> 
///     <description>Represents a font. Defines a particular format for text, including font face, size, and style attributes.</description>
///   </item>
///   <item>
///     <term><see cref="Text"/></term> 
///     <description>Represents comment text.</description>
///   </item>
/// </list>
/// </remarks>
public partial class Comment
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FontModel _font;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="Comment"/> class.
    /// </summary>
    public Comment()
    {
        Show = DefaultShow;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the font model.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of a font.            
    /// </value>
    /// <remarks>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Comment>
    ///   <Font/>
    /// </Comment>
    /// ]]>
    /// </code>
    /// </remarks>
    public FontModel Font
    {
        get => _font ??= new FontModel();
        set => _font = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether displays a comment that contains the original value of the field.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes" /> displays a comment that contains the original value of the field; Otherwise, <see cref="YesNo.No" />. The default is <see cref="YesNo.Yes" />.
    /// </value>
    /// <remarks>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Comment Show="Yes|No" ...>
    /// ...
    /// </Comment>
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
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => GetStaticBindingValue(_show.ToString()).ToLowerInvariant() == "no" ? YesNo.No : YesNo.Yes;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _show = value;
        }
    }

    /// <summary>
    /// Gets or sets the comment text.
    /// </summary>
    /// <value>
    /// The comment text.
    /// </value>
    /// <remarks>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Comment .../>
    ///   <Text>string</Text>
    ///   ...
    /// </Comment>
    /// ]]>
    /// </code>
    /// </remarks>
    public string Text { get; set; }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise <strong>false</strong>.
    /// </value>
    public override bool IsDefault =>
        Font.IsDefault &&
        string.IsNullOrEmpty(Text) &&
        Show.Equals(DefaultShow);

    #endregion
}
