
using System.ComponentModel;
using System.Diagnostics;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="RealDataType"/> class.<br/>
/// Displays a number in exponential notation, which replaces part of the number with E + n, where E (exponent) multiplies the preceding number by 10 to n.
/// You can specify the number of decimal places you want to use.
/// </summary>
/// <remarks>
/// <para><strong><u>Usage</u></strong>:</para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Scientific ...>
///   <Error/>
/// <Scientific/>
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
///     <description>Reference for percentage data type error settings.</description>
///   </item>
/// </list>
/// <para><strong><u>Examples</u></strong>:</para>
/// <example>
/// The following example indicate that the content should be scientific data type.
/// <code lang="xml">
/// <![CDATA[
/// <Scientific Decimals="3">
///   <Error Value="-9999">
///     <Comment Show="Yes">
///       <Text>Wrong value:  </Text>
///     </Comment>
///   </Error>           
/// </Scientific>
/// ]]>
/// </code>
/// </example>
/// </remarks>
public partial class ScientificDataType
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private ScientificError _error;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains scientific data type error settings.
    /// </summary>
    /// <value>
    /// Scientific data type error settings
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// <code lang="xml">
    /// <![CDATA[
    /// <Scientific Decimals="3">
    ///   <Error Value="-9999">
    ///     <Comment Show="Yes">
    ///       <Text>Wrong value: Your comment here!</Text>
    ///     </Comment>
    ///   </Error>           
    /// </Scientific>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Scientific ...>
    ///   <Error/>
    /// </Scientific>
    /// ]]>
    /// </code>
    /// </remarks>
    public ScientificError Error
    {
        get => _error ??= new ScientificError();
        set => _error = value;
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
        Error.IsDefault;

    #endregion
}
