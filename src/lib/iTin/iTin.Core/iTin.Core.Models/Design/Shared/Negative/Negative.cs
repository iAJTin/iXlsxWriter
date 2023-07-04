
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Core.Models.Design;

/// <summary>
/// Represents a negative number format. Contains the definition of negative number in a numeric data type.
/// </summary>
/// <remarks>
/// <para>
/// <para><u><strong>Usage</strong></u></para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Negative .../>
/// ]]>
/// </code>
/// </para>
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
///       <td><see cref="Color"/></td>
///       <td align="center">Yes</td>
///       <td>Preferred color for display a negative number. The default is <see cref="KnownBasicColor.Black"/>.</td>
///     </tr>
///     <tr>
///       <td><see cref="Sign"/></td>
///       <td align="center">Yes</td>
///       <td>Visual format of negative value. The default is <see cref="KnownNegativeSign.Standard"/>.</td>
///     </tr>
///   </tbody>
/// </table>
/// <para><u><strong>Examples</strong></u></para>
/// <example>
/// In the following example shows how create a new style (XML).
/// <code lang="xml">
/// <![CDATA[
/// <Style Name="TopAggregate">
///   <Content Color="#C9C9C9">
///     <Alignment Horizontal="Center"/>
///     <Number Decimals="0" Separator="Yes">
///       <Negative Color="Yellow" Sign="Brackets"/>
///     </Number>
///   </Content>
///   <Font Name="Segoe UI" Size="12" Color="Navy" Bold="Yes"/>
/// </Style>
/// ]]>
/// </code>
/// In the following example shows how create a new style (c#).
/// <code lang="cs">
/// StyleModel style = new StyleModel
/// {
///     Name = "TopAggregate",
///     Content = new ContentModel
///     {
///         Color = "#C9C9C9",
///         Alignment = new ContentAlignmentModel
///         {
///             Horizontal = KnownHorizontalAlignment.Center
///         },
///         DataType = new NumberDataTypeModel
///         {
///             Decimals = 0,
///             Separator = YesNo.Yes,
///             Negative = new NegativeModel
///             {
///                 Color = KnownBasicColor.Yellow,
///                 Sign = KnownNegativeSign.Brackets
///             }
///         }
///     },
///     Font = new FontModel
///     {
///         Color = "Navy",
///         Bold = YesNo.Yes,
///         Size = 12
///     }
/// };
/// </code>
/// </example>
/// </remarks>
public partial class Negative
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownBasicColor DefaultColor = KnownBasicColor.Black;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownNegativeSign DefaultSign = KnownNegativeSign.Standard;

    #endregion
        
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownBasicColor _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownNegativeSign _sign;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="Negative"/> class.
    /// </summary>
    public Negative()
    {
        Sign = DefaultSign;
        Color = DefaultColor;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred color for display a negative number.
    /// </summary>
    /// <value>
    /// Preferred color for display a negative number. The default is <see cref="KnownBasicColor.Black"/>.
    /// <para><u><strong>Examples</strong></u></para>
    /// <example>
    /// In the following example shows how create a new style (XML).
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="TopAggregate">
    ///   <Content Color="#C9C9C9">
    ///     <Alignment Horizontal="Center"/>
    ///     <Number Decimals="0" Separator="Yes">
    ///       <Negative Color="Yellow" Sign="Brackets"/>
    ///     </Number>
    ///   </Content>
    ///   <Font Name="Segoe UI" Size="12" Color="Navy" Bold="Yes"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// In the following example shows how create a new style (c#).
    /// <code lang="cs">
    /// StyleModel style = new StyleModel
    /// {
    ///     Name = "TopAggregate",
    ///     Content = new ContentModel
    ///     {
    ///         Color = "#C9C9C9",
    ///         Alignment = new ContentAlignmentModel
    ///         {
    ///             Horizontal = KnownHorizontalAlignment.Center
    ///         },
    ///         DataType = new NumberDataTypeModel
    ///         {
    ///             Decimals = 0,
    ///             Separator = YesNo.Yes,
    ///             Negative = new NegativeModel
    ///             {
    ///                 Color = KnownBasicColor.Yellow,
    ///                 Sign = KnownNegativeSign.Brackets
    ///             }
    ///         }
    ///     },
    ///     Font = new FontModel
    ///     {
    ///         Color = "Navy",
    ///         Bold = YesNo.Yes,
    ///         Size = 12
    ///     }
    /// };
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Negative Color="Black|Blue|Cyan|Green|Magenta|Red|Yellow|White" .../>
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
    [DefaultValue(DefaultColor)]
    public KnownBasicColor Color
    {
        get => _color;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _color = value;
        }
    }

    /// <summary>
    /// Gets or sets visual format of negative value.
    /// </summary>
    /// <value>
    /// Visual format of negative value. The default is <see cref="KnownNegativeSign.Standard"/>.
    /// <para><u><strong>Examples</strong></u></para>
    /// <example>
    /// In the following example shows how create a new style (XML).
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="TopAggregate">
    ///   <Content Color="#C9C9C9">
    ///     <Alignment Horizontal="Center"/>
    ///     <Number Decimals="0" Separator="Yes">
    ///       <Negative Color="Yellow" Sign="Brackets"/>
    ///     </Number>
    ///   </Content>
    ///   <Font Name="Segoe UI" Size="12" Color="Navy" Bold="Yes"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// In the following example shows how create a new style (c#).
    /// <code lang="cs">
    /// StyleModel style = new StyleModel
    /// {
    ///     Name = "TopAggregate",
    ///     Content = new ContentModel
    ///     {
    ///         Color = "#C9C9C9",
    ///         Alignment = new ContentAlignmentModel
    ///         {
    ///             Horizontal = KnownHorizontalAlignment.Center
    ///         },
    ///         DataType = new NumberDataTypeModel
    ///         {
    ///             Decimals = 0,
    ///             Separator = YesNo.Yes,
    ///             Negative = new NegativeModel
    ///             {
    ///                 Color = KnownBasicColor.Yellow,
    ///                 Sign = KnownNegativeSign.Brackets
    ///             }
    ///         }
    ///     },
    ///     Font = new FontModel
    ///     {
    ///         Color = "Navy",
    ///         Bold = YesNo.Yes,
    ///         Size = 12
    ///     }
    /// };
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Negative Sign="Standard|None|Parenthesis|Brackets" .../>
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
    [DefaultValue(DefaultSign)]
    public KnownNegativeSign Sign
    {
        get => _sign;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _sign = value;
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
        Sign.Equals(DefaultSign) && 
        Color.Equals(DefaultColor);

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure preferred for this negative format.
    /// </summary>
    /// <returns>
    /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns> 
    public Color GetColor()
    {
        var basiccolor = System.Drawing.Color.FromName(Color.ToString()).Name;

        return ColorHelper.GetColorFromString(basiccolor);
    }

    #endregion
}
