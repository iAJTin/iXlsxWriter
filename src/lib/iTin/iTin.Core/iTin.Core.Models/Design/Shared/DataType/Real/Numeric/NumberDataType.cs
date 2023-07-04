
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="NumericDataType"/> class.<br/>
/// You can specify the number of decimal places that you want to use, whether you want to use a thousands separator, and how you want to display negative numbers. 
/// </summary>
/// <remarks>
/// <para>Belongs to: <strong><see cref="BaseDataContent"/></strong>. For more information, please see <see cref="IContent"/>.</para>
/// <para><strong><u>Usage</u></strong>:</para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Number ...>
///   <Negative/>
///   <Error/>
/// <Number/>
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
///       <td><see cref="RealDataType.Decimals"/></td>
///       <td align="center">Yes</td>
///       <td>Number of decimal places. The default is <c>2</c>.</td>
///     </tr>
///     <tr>
///       <td><see cref="Separator"/></td>
///       <td align="center">Yes</td>
///       <td>Determines whether to display the thousands separator. The default is <see cref="YesNo.No"/>.</td>
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
///     <term><see cref="NumericDataType.Error"/></term> 
///     <description>Reference for numeric data type error settings.</description>
///   </item>
///   <item>
///     <term><see cref="NumericDataType.Negative"/></term> 
///     <description>Reference for negative number format.</description>
///   </item>
/// </list>
/// <para><strong><u>Examples</u></strong>:</para>
/// <example>
/// The following example indicate that the content should be number data type.
/// <code lang="xml">
/// <![CDATA[
/// <Style Name="TopAggregate">
///   <Content Color="#C9C9C9">
///     <Alignment Horizontal="Center"/>
///     <Number Decimals="0" Separator="Yes">
///       <Negative Color="Yellow" Sign="Brackets"/>
///       <Error Value="-9999">
///         <Comment Show="Yes">
///           <Text>Original value:  </Text>
///           <Font Size="12" Color="Navy"/>
///         </Comment>
///       </Error>           
///     </Number>
///   </Content>
///   <Font Name="Segoe UI" Size="12" Color="Navy" Bold="Yes"/>
/// </Style>
/// ]]>
/// </code>
/// </example>
/// </remarks>
public partial class NumberDataType
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultSeparator = YesNo.No;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _separator;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberDataType"/> class.
    /// </summary>
    public NumberDataType()
    {
        Separator = DefaultSeparator;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether displays thousands separator.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if displays thousands separator; otherwise, <see cref="YesNo.No"/>. The default is <see cref="YesNo.No"/>.
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// In the following example shows how create a new style.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="TopAggregate">
    ///   <Content Color="#C9C9C9">
    ///     <Alignment Horizontal="Center"/>
    ///     <Number Decimals="0" Separator="Yes">
    ///       <Negative Color="Yellow" Sign="Brackets"/>
    ///       <Error Value="-9999">
    ///         <Comment Show="Yes">
    ///           <Text>Original value:  </Text>
    ///           <Font Size="12" Color="Navy"/>
    ///         </Comment>
    ///       </Error>           
    ///     </Number>
    ///   </Content>
    ///   <Font Name="Segoe UI" Size="12" Color="Navy" Bold="Yes"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Number Separator="Yes|No" ...>
    /// ...
    /// </Number>
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
    [DefaultValue(DefaultSeparator)]
    public YesNo Separator
    {
        get => GetStaticBindingValue(_separator.ToString()).ToUpperInvariant() == "NO" ? YesNo.No : YesNo.Yes;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _separator = value;
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
        Separator.Equals(DefaultSeparator);

    #endregion
}
