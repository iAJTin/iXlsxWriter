
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="BaseError"/> class.
/// Which acts as the base class of error structures for numerical data.
/// </summary>
/// <remarks>
///   <para>The following table shows the different data types error structures.</para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="PercentageError"/></term>
///       <description>Represents the error structure for percentage data type.</description>
///     </item>
///     <item>
///       <term><see cref="ScientificError"/></term>
///       <description>Represents the error structure for scientific data type.</description>
///     </item>
///   </list>
/// </remarks>        
public partial class NumericError
{
    #region internal constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal const float DefaultValue = 0.0f;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericError"/> class.
    /// </summary>
    public NumericError()
    {
        Value = DefaultValue;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred default value when occurs an error.
    /// </summary>
    /// <value>
    /// Preferred default value when occurs an error. The default is <c>0.0</c>.
    /// <para><strong><u>Examples</u></strong></para>
    /// <example>
    /// In the following example shows how create a new style with a currency data type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="Account">
    ///   <Content Color="Blue">
    ///     <Number Decimals="1">
    ///       <Negative Color="Red" Sign="Parenthesis">
    ///       <Error Value="99">
    ///         <Comment Show="Yes">
    ///           <Text>Wrong value: </Text>
    ///         </Comment>
    ///       </Error>
    ///     </Currency>
    ///   </Content>
    ///   <Font Size="8" Color="White"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Error Value="float" ...>
    ///   ...
    /// </Error>
    /// ]]>
    /// </code>
    /// </remarks>
    [XmlAttribute]
    [DefaultValue(DefaultValue)]
    public float Value { get; set; }

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
        Value.Equals(DefaultValue);

    #endregion
}
