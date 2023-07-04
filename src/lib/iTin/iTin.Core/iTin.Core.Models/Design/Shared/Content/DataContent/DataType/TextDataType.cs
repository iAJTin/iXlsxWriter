
namespace iTin.Core.Models.Design.Styling.Style.Content
{
    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br />
    /// Treats the content as text and displays the content exactly as written, even when numbers are typed.
    /// </summary>
    /// <remarks>
    /// <para>Belongs to: <strong><see cref="BaseDataContent"/></strong>. For more information, please see <see cref="IContent"/>.</para>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Text/>
    /// ]]>
    /// </code>
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// The following example indicate that the content should be text type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="PurchaseOrderValue">
    ///   <Content Color="White">
    ///     <Text/>
    ///   </Content>
    ///   <Font Size="10"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// </example>
    /// </remarks>
    public partial class TextDataType
    {
    }
}
