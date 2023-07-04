
using System.ComponentModel;
using System.Diagnostics;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="RealDataType"/> class.<br/>
/// Displays the result with a percent sign (%). You can specify the number of decimal places to use.
/// </summary>
/// <remarks>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Percentage ...>
///   <Error/>
/// <Percentage/>
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
/// The following example indicate that the content should be percentage data type.
/// <code lang="xml">
/// <![CDATA[
/// <Percentage Decimals="1">
///   <Error Value="0">
///     <Comment Show="Yes">
///       <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes" Color="Navy"/>
///     </Comment>
///   </Error>
/// </Percentage>
/// ]]>
/// </code>
/// </example>
/// </remarks>
public partial class PercentageDataType
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private PercentageError _error;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains percentage data type error settings.
    /// </summary>
    /// <value>
    /// Percentage data type error settings
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// In the following example shows how create a new style with a percentage data type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Percentage Decimals="1">
    ///   <Error Value="0">
    ///     <Comment Show="Yes">
    ///       <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes" Color="Navy"/>
    ///     </Comment>
    ///   </Error>
    /// </Percentage>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Percentage ...>
    ///   <Error/>
    /// </Percentage>
    /// ]]>
    /// </code>
    /// </remarks>
    public PercentageError Error
    {
        get => _error ??= new PercentageError();
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
