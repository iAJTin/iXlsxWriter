
namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="NumericError"/> class.
/// Represents the error structure for scientific data type. Allows us to set a default value and an additional comment.
/// </summary>
/// <remarks>
/// <para>Belongs to: <strong><c>Scientific</c></strong>. For more information, please see <see cref="ScientificDataType"/>.</para>
/// <para><u><strong>Usage</strong></u></para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Error ...>
///   <Comment/>
/// </Error>
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
///       <td><see cref="NumericError.Value"/></td>
///       <td align="center">Yes</td>
///       <td>Preferred default value when occurs an error. The default is <c>0.0</c>.</td>
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
///     <term><see cref="BaseError.Comment"/></term> 
///     <description>Reference for error comment. Includes comment text, format, including font face, size, and style attributes.</description>
///   </item>
/// </list>
/// <para><strong><u>Examples</u></strong></para>
/// <example>
/// In the following example shows how create a new style with a scientific data type.
/// <code lang="xml">
/// <![CDATA[
/// <Scientific Decimals="3">
///   <Error Value="-9999">
///     <Comment Show="Yes">
///       <Text>Wrong value: </Text>
///     </Comment>
///   </Error>           
/// </Scientific>
/// ]]>
/// </code>
/// </example>
/// </remarks>
public partial class ScientificError
{
}
